
-- TABLA EVENTOS

CREATE TABLE eventos (
    codigo_evento SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    cupo_maximo INT NOT NULL,
    inscritos_actuales INT DEFAULT 0,
    activo BOOLEAN DEFAULT TRUE
);

-- TABLA PERSONAS

CREATE TABLE personas (
    codigo_persona SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    bloqueado BOOLEAN DEFAULT FALSE
);


-- TABLA INSCRIPCIONES

CREATE TABLE inscripciones (
    id_inscripcion SERIAL PRIMARY KEY,
    codigo_evento INT NOT NULL,
    codigo_persona INT NOT NULL,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    usuario VARCHAR(50),

    CONSTRAINT fk_evento
        FOREIGN KEY (codigo_evento)
        REFERENCES eventos (codigo_evento),

    CONSTRAINT fk_persona
        FOREIGN KEY (codigo_persona)
        REFERENCES personas (codigo_persona),

    CONSTRAINT unica_inscripcion
        UNIQUE (codigo_evento, codigo_persona)
);


-- TABLA HISTORIAL

CREATE TABLE historial_movimientos (
    id_historial SERIAL PRIMARY KEY,
    descripcion TEXT,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    usuario VARCHAR(50)
);


-- TABLA ALERTAS

CREATE TABLE alertas (
    id_alerta SERIAL PRIMARY KEY,
    codigo_evento INT,
    mensaje TEXT,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_evento_alerta
        FOREIGN KEY (codigo_evento)
        REFERENCES eventos (codigo_evento)
);

INSERT INTO eventos (nombre, cupo_maximo, inscritos_actuales, activo)
VALUES
('Evento IA', 10, 0, true),
('Evento Programacion', 5, 0, true),
('Evento Cancelado', 10, 0, false);


INSERT INTO personas (nombre, bloqueado)
VALUES
('Juan', false),
('Maria', false),
('Pedro', true);

-- Eventos
INSERT INTO eventos (nombre, cupo_maximo, inscritos_actuales, activo) VALUES
('Conferencia de Tecnología', 50, 0, TRUE),
('Taller de Programación',    20, 0, TRUE),
('Seminario de Base de Datos', 10, 0, TRUE);

-- Personas
INSERT INTO personas (nombre, bloqueado) VALUES
('Carlos Pérez',   FALSE),
('María González', FALSE),
('Luis Martínez',  FALSE);

CREATE OR REPLACE FUNCTION registrar_inscripcion(
    p_codigo_evento     INT,
    p_codigo_persona    INT,
    p_usuario           VARCHAR
)
RETURNS JSON
LANGUAGE plpgsql
AS $$
DECLARE
    v_cupo_maximo       INT;
    v_inscritos_actual  INT;
    v_cupo_disponible   INT;
BEGIN

    -- 1. Validar que el evento exista y esté activo
    SELECT cupo_maximo, inscritos_actuales
    INTO v_cupo_maximo, v_inscritos_actual
    FROM eventos
    WHERE codigo_evento = p_codigo_evento
      AND activo = TRUE;

    IF NOT FOUND THEN
        RETURN json_build_object(
            'exito',   false,
            'mensaje', 'El evento no existe o no está activo.'
        );
    END IF;

    -- 2. Validar que la persona exista y no esté bloqueada
    IF NOT EXISTS (
        SELECT 1 FROM personas
        WHERE codigo_persona = p_codigo_persona
          AND bloqueado = FALSE
    ) THEN
        RETURN json_build_object(
            'exito',   false,
            'mensaje', 'La persona no existe o se encuentra bloqueada.'
        );
    END IF;

    -- 3. Verificar que no esté inscrita previamente
    IF EXISTS (
        SELECT 1 FROM inscripciones
        WHERE codigo_evento  = p_codigo_evento
          AND codigo_persona = p_codigo_persona
    ) THEN
        RETURN json_build_object(
            'exito',   false,
            'mensaje', 'La persona ya está inscrita en este evento.'
        );
    END IF;

    -- 4. Verificar cupo disponible
    v_cupo_disponible := v_cupo_maximo - v_inscritos_actual;

    IF v_cupo_disponible <= 0 THEN
        RETURN json_build_object(
            'exito',   false,
            'mensaje', 'El evento no tiene cupo disponible.'
        );
    END IF;

    -- 5. Insertar inscripción
    INSERT INTO inscripciones (codigo_evento, codigo_persona, fecha, usuario)
    VALUES (p_codigo_evento, p_codigo_persona, NOW(), p_usuario);

    -- 6. Actualizar inscritos en el evento
    UPDATE eventos
    SET inscritos_actuales = inscritos_actuales + 1
    WHERE codigo_evento = p_codigo_evento;

    -- 7. Registrar en historial
    INSERT INTO historial_movimientos (descripcion, usuario, fecha)
    VALUES (
        'Inscripción de persona ' || p_codigo_persona ||
        ' al evento '            || p_codigo_evento,
        p_usuario,
        NOW()
    );

    -- 8. Alerta si cupo restante < 5
    IF (v_cupo_disponible - 1) < 5 THEN
        INSERT INTO alertas (codigo_evento, mensaje, fecha)
        VALUES (
            p_codigo_evento,
            'El evento ' || p_codigo_evento ||
            ' está próximo a llenarse. Cupo restante: ' ||
            (v_cupo_disponible - 1)::TEXT,
            NOW()
        );
    END IF;

    RETURN json_build_object(
        'exito',   true,
        'mensaje', 'Inscripción registrada exitosamente.'
    );

EXCEPTION
    WHEN OTHERS THEN
        RETURN json_build_object(
            'exito',   false,
            'mensaje', 'Error interno: ' || SQLERRM
        );
END;
$$;


select * from historial_movimientos
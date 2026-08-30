-- =========================================================
-- Examen Parcial - Script de creación de base de datos local
-- Motor: PostgreSQL
-- =========================================================

-- 1. Crear la base de datos (ejecutar conectado a la BD "postgres" u otra existente).
CREATE DATABASE "EXAMEN_PARCIAL";

-- 2. Conectarse a la base recién creada antes de continuar.
--    En psql:  \c EXAMEN_PARCIAL

-- 3. Tabla de pedidos.
CREATE TABLE pedido (
    id_pedido         SERIAL PRIMARY KEY,
    numero_pedido     VARCHAR(20)     NOT NULL UNIQUE,
    nombre_cliente    VARCHAR(150)    NOT NULL,
    direccion_entrega VARCHAR(250)    NOT NULL,
    monto             NUMERIC(12, 2)  NOT NULL CHECK (monto >= 0),
    estado            VARCHAR(30)     NOT NULL DEFAULT 'Pendiente',
    fecha_registro    TIMESTAMP       NOT NULL DEFAULT NOW(),
    usuario           VARCHAR(100)    NOT NULL
);

-- Índice útil para búsquedas por estado.
CREATE INDEX idx_pedido_estado ON pedido (estado);

-- =========================================================
-- Notas:
-- - La cadena de conexión usada por la API está en
--   Examen_Parcial/appsettings.json (ConnectionStrings:DefaultConnection).
--   Ajusta usuario/contraseña/puerto según tu instalación local.
-- - El historial de altas y modificaciones de cada pedido se guarda
--   en MongoDB (base "ExamenParcial", colección "Pedido_Historial"),
--   no requiere script porque Mongo crea la base/colección al insertar
--   el primer documento.
-- =========================================================

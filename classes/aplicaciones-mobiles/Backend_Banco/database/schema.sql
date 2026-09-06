-- =========================================================
-- Backend_Banco - PostgreSQL schema
-- Database name taken from appsettings.json (DefaultConnection)
-- =========================================================

CREATE DATABASE "ENTIDAD_BANCARIA";

-- Connect to it before running the rest (psql: \c ENTIDAD_BANCARIA)

-- ---------------------------------------------------------
-- rol
-- Inferred: usuario.id_rol references it, but no table for it
-- exists yet in the codebase. Skip this block if you already
-- manage roles elsewhere.
-- ---------------------------------------------------------
CREATE TABLE rol (
    id_rol      SERIAL PRIMARY KEY,
    nombre      VARCHAR(50) NOT NULL UNIQUE
);

-- ---------------------------------------------------------
-- usuario  (Core/Servicios/UsuarioServicio.cs)
-- ---------------------------------------------------------
CREATE TABLE usuario (
    id_usuario      SERIAL PRIMARY KEY,
    nombre          VARCHAR(100) NOT NULL,
    usuario         VARCHAR(50)  NOT NULL UNIQUE,
    password        VARCHAR(255) NOT NULL,
    id_rol          INTEGER NOT NULL REFERENCES rol(id_rol),
    estado          BOOLEAN NOT NULL DEFAULT TRUE,
    fecha_creacion  TIMESTAMP NOT NULL DEFAULT NOW()
);

-- ---------------------------------------------------------
-- cliente  (Core/Servicios/ClienteServicio.cs)
-- ---------------------------------------------------------
CREATE TABLE cliente (
    id_cliente      SERIAL PRIMARY KEY,
    dpi             VARCHAR(20)  NOT NULL UNIQUE,
    nombres         VARCHAR(100) NOT NULL,
    apellidos       VARCHAR(100) NOT NULL,
    telefono        VARCHAR(20),
    correo          VARCHAR(150),
    direccion       VARCHAR(255),
    fecha_registro  TIMESTAMP NOT NULL DEFAULT NOW(),
    estado          BOOLEAN NOT NULL DEFAULT TRUE
);

-- ---------------------------------------------------------
-- cuenta
-- Inferred: movimiento.id_cuenta_origen/destino need an
-- accounts table that isn't created anywhere in the code yet.
-- Adjust/remove if you already have one.
-- ---------------------------------------------------------
CREATE TABLE cuenta (
    id_cuenta       SERIAL PRIMARY KEY,
    id_cliente      INTEGER NOT NULL REFERENCES cliente(id_cliente),
    numero_cuenta   VARCHAR(30) NOT NULL UNIQUE,
    tipo_cuenta     VARCHAR(30) NOT NULL,
    saldo           NUMERIC(15,2) NOT NULL DEFAULT 0,
    fecha_apertura  TIMESTAMP NOT NULL DEFAULT NOW(),
    estado          BOOLEAN NOT NULL DEFAULT TRUE
);

-- ---------------------------------------------------------
-- movimiento  (Core/Servicios/MovimientoServicio.cs, Modelo/MMovimiento.cs)
-- Column names in snake_case to match the Dapper mapping
-- convention used by cliente/usuario.
-- ---------------------------------------------------------
CREATE TABLE movimiento (
    id_movimiento       SERIAL PRIMARY KEY,
    id_cuenta_origen    INTEGER NOT NULL REFERENCES cuenta(id_cuenta),
    id_cuenta_destino   INTEGER REFERENCES cuenta(id_cuenta),
    monto               NUMERIC(15,2) NOT NULL,
    saldo_anterior      NUMERIC(15,2),
    saldo_nuevo         NUMERIC(15,2),
    descripcion         VARCHAR(255),
    fecha               TIMESTAMP NOT NULL DEFAULT NOW(),
    id_usuario          INTEGER NOT NULL REFERENCES usuario(id_usuario)
);

-- =========================================================
-- MongoDB (audit trail, no SQL needed)
-- Database: "Banco", Collection: "Movimiento_Proceso"
-- Document shape (Modelo/Modelos/MMovimientoMongo.cs):
--   { _id: ObjectId, IdMovimiento: int, EstadoProceso: string }
-- =========================================================

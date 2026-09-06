using Core.Interfaz;
using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Modelos;
using MongoDB.Driver;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class MovimientoServicio: IMovimiento
    {
        private readonly string _connectionString;
        private readonly IMongoCollection<MMovimientoMongo> _movimientosMongo;
        public MovimientoServicio(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "No se encontró la cadena de conexión DefaultConnection.");

            string mongoConnection =
    configuration.GetConnectionString("MongoDB")
    ?? throw new InvalidOperationException(
        "No se encontró MongoDB.");

            var mongoClient = new MongoClient(mongoConnection);

            var mongoDatabase = mongoClient.GetDatabase("BANCO");

            _movimientosMongo =
                mongoDatabase.GetCollection<MMovimientoMongo>("MOVIMIENTO_PROCESO");
        }

        private NpgsqlConnection CrearConexion()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<List<MMovimiento>> ObtenerTodos()
        {
            using var conexion = CrearConexion();

            string sql = @"
                SELECT
                    id_movimiento AS IdMovimiento,
                    id_cuenta_origen AS IdCuentaOrigen,
                    id_cuenta_destino AS IdCuentaDestino,
                    id_tipo_movimiento AS IdTipoMovimiento,
                    monto AS Monto,
                    saldo_anterior AS SaldoAnterior,
                    saldo_nuevo AS SaldoNuevo,
                    descripcion AS Descripcion,
                    fecha AS Fecha,
                    id_usuario AS IdUsuario
                FROM movimientos
                ORDER BY fecha DESC;
            ";

            var resultado = await conexion.QueryAsync<MMovimiento>(sql);

            return resultado.ToList();
        }

        public async Task<MMovimiento?> ObtenerPorId(int idMovimiento)
        {
            using var conexion = CrearConexion();

            string sql = @"
                SELECT
                    id_movimiento AS IdMovimiento,
                    id_cuenta_origen AS IdCuentaOrigen,
                    id_cuenta_destino AS IdCuentaDestino,
                    id_tipo_movimiento AS IdTipoMovimiento,
                    monto AS Monto,
                    saldo_anterior AS SaldoAnterior,
                    saldo_nuevo AS SaldoNuevo,
                    descripcion AS Descripcion,
                    fecha AS Fecha,
                    id_usuario AS IdUsuario
                FROM movimientos
                WHERE id_movimiento = @IdMovimiento;
            ";

            return await conexion.QueryFirstOrDefaultAsync<MMovimiento>(
                sql,
                new { IdMovimiento = idMovimiento }
            );
        }

        public async Task<List<MMovimiento>> ObtenerPorCuenta(int idCuenta)
        {
            using var conexion = CrearConexion();

            string sql = @"
                SELECT
                    id_movimiento AS IdMovimiento,
                    id_cuenta_origen AS IdCuentaOrigen,
                    id_cuenta_destino AS IdCuentaDestino,
                    id_tipo_movimiento AS IdTipoMovimiento,
                    monto AS Monto,
                    saldo_anterior AS SaldoAnterior,
                    saldo_nuevo AS SaldoNuevo,
                    descripcion AS Descripcion,
                    fecha AS Fecha,
                    id_usuario AS IdUsuario
                FROM movimientos
                WHERE id_cuenta_origen = @IdCuenta
                   OR id_cuenta_destino = @IdCuenta
                ORDER BY fecha DESC;
            ";

            var resultado = await conexion.QueryAsync<MMovimiento>(
                sql,
                new { IdCuenta = idCuenta }
            );

            return resultado.ToList();
        }

        public async Task<int> Insertar(MMovimiento movimiento)
        {
            using var conexion = CrearConexion();

            string sql = "INSERT INTO movimientos (id_cuenta_origen, id_cuenta_destino, id_tipo_movimiento, monto, saldo_anterior, saldo_nuevo, descripcion, id_usuario) VALUES (@IdCuentaOrigen, @IdCuentaDestino, @IdTipoMovimiento, @Monto, @SaldoAnterior, @SaldoNuevo, @Descripcion, @IdUsuario) RETURNING id_movimiento;";

            // INSERT EN POSTGRESQL
           // int idMovimiento = await conexion.ExecuteScalarAsync<int>(sql, movimiento);
            int idMovimiento = movimiento.IdMovimiento;
            // INSERT EN MONGODB
            var movimientoMongo = new MMovimientoMongo
            {
                IdMovimiento = movimiento.IdMovimiento,
                EstadoProceso = "PENDIENTE"
            };

            await _movimientosMongo.InsertOneAsync(movimientoMongo);

            return idMovimiento;
        }
    }
}

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
    public class MovimientoServicio : IMovimiento
    {
        private readonly string _connectionString;
        private readonly IMongoCollection<MMovimientoMongo> _movimientoCollection;

        public MovimientoServicio(IConfiguration configuration)
        {
            //Pos 
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión DefaultConnection.");
            //Mongo
            string mongoConnection = configuration.GetConnectionString("MongoDB") ??
                 throw new InvalidOperationException("No se encontro MongoDB");
            var mongoClient = new MongoClient(mongoConnection);
            var mongoDatabase = mongoClient.GetDatabase("Banco");
            _movimientoCollection = mongoDatabase.GetCollection<MMovimientoMongo>("Movimiento_Proceso");
        }

        private NpgsqlConnection CrearConexion()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<int> Insertar(MMovimiento movimiento)
        {
            using var conexion = CrearConexion();
            int idMovimiento = movimiento.IdMovimiento;
            string sql = "INSERT INTO Movimiento (IDCuentaOrigen, IdCuentaDestino, Monto, SaldoAnterior, SaldoNuevo, Descripcion, Fecha, IdUsuario) " +
                         "VALUES (@IDCuentaOrigen, @IdCuentaDestino, @Monto, @SaldoAnterior, @SaldoNuevo, @Descripcion, @Fecha, @IdUsuario) " +
                         "RETURNING IdMovimiento;"; 
            //Insert to PostgreSQL
            //idMovimiento = await conexion.ExecuteScalarAsync<int>(sql, movimiento);
            // Insert to MongoDB
            var movimientoMongo = new MMovimientoMongo
            {
                IdMovimiento = idMovimiento,
                EstadoProceso = "Pendiente"
            };
            await _movimientoCollection.InsertOneAsync(movimientoMongo);
            return idMovimiento;
        }
    }
}

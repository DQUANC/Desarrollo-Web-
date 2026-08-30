using Core.Interfaz;
using Dapper;
using Microsoft.Extensions.Configuration;
using Modelo.Modelos;
using MongoDB.Driver;
using Npgsql;
using System.Text;

namespace Core.Servicios
{
    public class PedidoServicio : IPedido
    {
        private readonly string _connectionString;
        private readonly IMongoCollection<MPedidoMongo> _pedidoHistorialCollection;

        public PedidoServicio(IConfiguration configuration)
        {
            // Postgres
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión DefaultConnection.");

            // Mongo
            string mongoConnection = configuration.GetConnectionString("MongoDB")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión MongoDB.");

            var mongoClient = new MongoClient(mongoConnection);
            var mongoDatabase = mongoClient.GetDatabase("ExamenParcial");
            _pedidoHistorialCollection = mongoDatabase.GetCollection<MPedidoMongo>("Pedido_Historial");
        }

        private NpgsqlConnection CrearConexion()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<List<MPedido>> ObtenerTodos()
        {
            try
            {
                const string sql = @"
                    SELECT
                        id_pedido AS IdPedido,
                        numero_pedido AS NumeroPedido,
                        nombre_cliente AS NombreCliente,
                        direccion_entrega AS DireccionEntrega,
                        monto AS Monto,
                        estado AS Estado,
                        fecha_registro AS FechaRegistro,
                        usuario AS Usuario
                    FROM pedido
                    ORDER BY id_pedido;";

                await using var connection = CrearConexion();

                var resultado = await connection.QueryAsync<MPedido>(sql);

                return resultado.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener pedidos: " + ex.Message);

                return new List<MPedido>();
            }
        }

        public async Task<MPedido?> ObtenerPorId(int id)
        {
            try
            {
                const string sql = @"
                    SELECT
                        id_pedido AS IdPedido,
                        numero_pedido AS NumeroPedido,
                        nombre_cliente AS NombreCliente,
                        direccion_entrega AS DireccionEntrega,
                        monto AS Monto,
                        estado AS Estado,
                        fecha_registro AS FechaRegistro,
                        usuario AS Usuario
                    FROM pedido
                    WHERE id_pedido = @IdPedido;";

                await using var connection = CrearConexion();

                var resultado =
                    await connection.QueryFirstOrDefaultAsync<MPedido>(sql, new { IdPedido = id });

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener pedido por ID: " + ex.Message);

                return null;
            }
        }

        public async Task<int> Insertar(MPedido pedido)
        {
            try
            {
                const string sql = @"
                    INSERT INTO pedido
                    (
                        numero_pedido,
                        nombre_cliente,
                        direccion_entrega,
                        monto,
                        estado,
                        usuario
                    )
                    VALUES
                    (
                        @NumeroPedido,
                        @NombreCliente,
                        @DireccionEntrega,
                        @Monto,
                        @Estado,
                        @Usuario
                    )
                    RETURNING id_pedido;";

                await using var connection = CrearConexion();

                int idPedido = await connection.ExecuteScalarAsync<int>(sql, pedido);

                // Registro del alta en MongoDB.
                var historial = new MPedidoMongo
                {
                    IdPedido = idPedido,
                    NumeroPedido = pedido.NumeroPedido,
                    Estado = pedido.Estado,
                    Fecha = DateTime.Now,
                    Descripcion = "Pedido registrado.",
                    TipoEvento = "Registro"
                };

                await _pedidoHistorialCollection.InsertOneAsync(historial);

                return idPedido;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar pedido: " + ex.Message);

                return 0;
            }
        }

        public async Task<bool> Actualizar(MPedido pedido)
        {
            try
            {
                var pedidoAnterior = await ObtenerPorId(pedido.IdPedido);
                if (pedidoAnterior == null)
                {
                    return false;
                }

                const string sql = @"
                    UPDATE pedido
                    SET
                        numero_pedido = @NumeroPedido,
                        nombre_cliente = @NombreCliente,
                        direccion_entrega = @DireccionEntrega,
                        monto = @Monto,
                        estado = @Estado,
                        usuario = @Usuario
                    WHERE id_pedido = @IdPedido;";

                await using var connection = CrearConexion();

                int filasAfectadas = await connection.ExecuteAsync(sql, pedido);

                if (filasAfectadas <= 0)
                {
                    return false;
                }

                // Registro de la modificación en MongoDB, detallando qué cambió.
                string descripcion = DescribirCambios(pedidoAnterior, pedido);

                var historial = new MPedidoMongo
                {
                    IdPedido = pedido.IdPedido,
                    NumeroPedido = pedido.NumeroPedido,
                    Estado = pedido.Estado,
                    Fecha = DateTime.Now,
                    Descripcion = descripcion,
                    TipoEvento = "Modificacion"
                };

                await _pedidoHistorialCollection.InsertOneAsync(historial);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar pedido: " + ex.Message);

                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                const string sql = @"
                    DELETE FROM pedido
                    WHERE id_pedido = @IdPedido;";

                await using var connection = CrearConexion();

                int resultado = await connection.ExecuteAsync(sql, new { IdPedido = id });

                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar pedido: " + ex.Message);

                return false;
            }
        }

        private static string DescribirCambios(MPedido anterior, MPedido nuevo)
        {
            var cambios = new StringBuilder();

            void Comparar(string campo, object? valorAnterior, object? valorNuevo)
            {
                string anteriorTexto = valorAnterior?.ToString() ?? string.Empty;
                string nuevoTexto = valorNuevo?.ToString() ?? string.Empty;

                if (!anteriorTexto.Equals(nuevoTexto, StringComparison.Ordinal))
                {
                    cambios.Append($"{campo}: '{anteriorTexto}' -> '{nuevoTexto}'. ");
                }
            }

            Comparar("NumeroPedido", anterior.NumeroPedido, nuevo.NumeroPedido);
            Comparar("NombreCliente", anterior.NombreCliente, nuevo.NombreCliente);
            Comparar("DireccionEntrega", anterior.DireccionEntrega, nuevo.DireccionEntrega);
            Comparar("Monto", anterior.Monto, nuevo.Monto);
            Comparar("Estado", anterior.Estado, nuevo.Estado);
            Comparar("Usuario", anterior.Usuario, nuevo.Usuario);

            return cambios.Length > 0
                ? cambios.ToString().Trim()
                : "Pedido actualizado sin cambios detectados.";
        }
    }
}

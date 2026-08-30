using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Modelo.Modelos
{
    // Bitácora de Pedido guardada en MongoDB.
    // Se agrega un registro cuando el pedido se crea (POST) y otro cada vez
    // que se modifica (PUT), para llevar un historial de los cambios.
    public class MPedidoMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int IdPedido { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        // "Registro" cuando se crea el pedido, "Modificacion" cuando se actualiza.
        public string TipoEvento { get; set; } = "Registro";
    }
}

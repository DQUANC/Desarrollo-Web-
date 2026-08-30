using System;

namespace Modelo.Modelos
{
    public class MPedido
    {
        public int IdPedido { get; set; }
        public string NumeroPedido { get; set; } = string.Empty;
        public string NombreCliente { get; set; } = string.Empty;
        public string DireccionEntrega { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public DateTime FechaRegistro { get; set; }
        public string Usuario { get; set; } = string.Empty;
    }
}

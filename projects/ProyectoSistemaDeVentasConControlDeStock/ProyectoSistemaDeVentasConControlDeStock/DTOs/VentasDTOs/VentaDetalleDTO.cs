namespace ProyectoSistemaDeVentasConControlDeStock.DTOs.VentasDTOs
{
    public class VentaDetalleDTO
    {
        public int id_venta { get; set; }
        public string nombre_producto { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set; }
        public DateTime fecha { get; set; }
    }
}
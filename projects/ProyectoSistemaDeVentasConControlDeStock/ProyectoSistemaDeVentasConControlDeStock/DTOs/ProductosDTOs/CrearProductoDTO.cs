using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSistemaDeVentasConControlDeStock.DTOs.ProductosDTOs
{
    public class CrearProductoDTO
    {
        [Required]
        [Column("nombre_producto")]
        public string nombre_producto { get; set; }

        [Required]
        [Column("precio")]
        public decimal precio { get; set; }

        [Required]
        [Column("stock")]
        public int stock { get; set; }
    }
}

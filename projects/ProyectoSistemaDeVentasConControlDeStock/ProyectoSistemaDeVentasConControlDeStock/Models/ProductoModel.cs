using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaDeVentasConControlDeStock.Models
{
    public class ProductoModel
    {
        [Key]
        [Column("sku_producto")]
        public int sku_producto { get; set; }

        [Required]
        [Column("nombre_producto")]
        public string nombre_producto { get; set; }

        [Required]
        [Column("precio")]
        public decimal precio {  get; set; }

        [Required]
        [Column("stock")]
        public int stock { get; set; }
    }
}

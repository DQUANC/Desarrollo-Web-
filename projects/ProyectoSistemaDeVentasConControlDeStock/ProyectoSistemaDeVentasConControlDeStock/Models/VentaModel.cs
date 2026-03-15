using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoSistemaDeVentasConControlDeStock.Models
{
    public class VentaModel
    {
        [Key]
        [Column("id_venta")]
        public int id_venta { get; set; }

        [Required]
        [Column("SKU_producto")]
        public int SKU_producto { get; set; }

        [Required]
        [Column("cantidad")]
        public int cantidad { get; set; }
    }
}

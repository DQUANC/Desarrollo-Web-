using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSistemaDeVentasConControlDeStock.DTOs.ProductosDTOs
{
    public class EliminarProductoDTO
    {
        [Key]
        [Column("SKU_producto")]
        public int SKU_producto { get; set; }
    }
}

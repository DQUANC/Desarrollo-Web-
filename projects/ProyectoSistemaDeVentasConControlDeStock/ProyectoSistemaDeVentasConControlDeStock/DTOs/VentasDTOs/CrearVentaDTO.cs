using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSistemaDeVentasConControlDeStock.DTOs.VentasDTOs
{
    public class CrearVentaDTO
    {
        [Required]
        [Column("sku_producto")]
        public int sku_producto { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        [Column("cantidad")]
        public int cantidad { get; set; }
    }
}
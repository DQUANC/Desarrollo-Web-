using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Final_DesarrolloWeb1.Models
{
    public class Historial_MovimientosModel
    {
        [Key]
        [Column("id_historial")]
        public int id_historial { get; set; }

        [Required]
        [Column("descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime fecha { get; set; }

        [Required]
        [Column("usuario")]
        public string usuario { get; set; }
    }
}

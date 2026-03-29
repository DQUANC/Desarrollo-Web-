using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Final_DesarrolloWeb1.Models
{
    public class AlertasModel
    {
        [Key]
        [Column("id_alerta")]
        public int id_alerta { get; set; }

        [Required]
        [Column("codigo_evento")]
        public int codigo_evento { get; set; }

        [Required]
        [Column("mensaje")]
        public string mensaje { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime fecha { get; set; }
    }
}

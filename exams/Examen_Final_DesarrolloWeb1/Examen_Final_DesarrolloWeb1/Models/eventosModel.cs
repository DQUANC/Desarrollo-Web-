using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Final_DesarrolloWeb1.Models
{
    public class EventosModel
    {
        [Key]
        [Column("codigo_evento")]
        public int codigo_evento { get; set; }

        [Column("nombre")]
        public string nombre { get; set; } = string.Empty;

        [Column("cupo_maximo")]
        public int cupo_maximo { get; set; }

        [Column("inscritos_actuales")]
        public int inscritos_actuales { get; set; }

        [Column("activo")]
        public bool activo { get; set; }
    }
}
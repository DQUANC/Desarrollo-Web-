using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Final_DesarrolloWeb1.Models
{
    public class InscripcionesModel
    {
        [Key]
        [Column("id_inscripcion")]
        public int id_inscripcion { get; set; }

        [Required]
        [Column("codigo_evento")]
        public int codigo_evento { get; set; }

        [Required]
        [Column("codigo_persona")]
        public int codigo_persona { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }

        [Column("usuario")]
        public string usuario { get; set; } = string.Empty;
    }
}
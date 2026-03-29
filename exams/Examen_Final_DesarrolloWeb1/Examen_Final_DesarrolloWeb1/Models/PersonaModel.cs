using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_Final_DesarrolloWeb1.Models
{
    public class PersonaModel
    {
        [Key]
        [Column("codigo_persona")]
        public int codigo_persona { get; set; }

        [Column("nombre")]
        public string nombre { get; set; } = string.Empty;

        [Column("bloqueado")]
        public bool bloqueado { get; set; }
    }
}
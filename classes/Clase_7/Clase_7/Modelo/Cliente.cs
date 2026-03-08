using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clase_7.Modelo
{
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int id_cliente { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column("correo")]
        public string Correo { get; set; } = string.Empty;

        [Column("telefono")]
        public string? Telefono {  get; set; }
    }
}

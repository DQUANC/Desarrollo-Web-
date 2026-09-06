using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    public class MCliente
    {
        public int IdCliente { get; set; }
        public string Dpi { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}

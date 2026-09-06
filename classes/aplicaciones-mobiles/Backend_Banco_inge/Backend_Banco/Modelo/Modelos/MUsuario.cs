using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    public class MUsuario
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string UsuarioLogin { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public int IdRol { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

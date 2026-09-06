using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Modelos
{
    public class MMovimiento
    {
        public int IdMovimiento { get; set; }
        public int IDCuentaOrigen { get; set; }
        public int? IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public decimal? SaldoAnterior { get; set; }
        public decimal? SaldoNuevo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
    }
}

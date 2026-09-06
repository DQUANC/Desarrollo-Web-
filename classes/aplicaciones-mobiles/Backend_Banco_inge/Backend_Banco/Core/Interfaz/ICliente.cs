using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaz
{
    public interface ICliente
    {
        Task<List<MCliente>> ObtenerTodos();
        Task<MCliente?> ObtenerPorId(int id);
        Task<MCliente?> ObtenerPorDpi(string dpi);
        Task<bool> Insertar(MCliente cliente);
        Task<bool> Actualizar(MCliente cliente);
        Task<bool> CambiarEstado(int id, bool estado);
        Task<bool> Eliminar(int id);
    }
}

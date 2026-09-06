using Modelo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaz
{
    public interface IMovimiento
    {
        Task<List<MMovimiento>> ObtenerTodos();
        Task<MMovimiento?> ObtenerPorId(int idMovimiento);
        Task<List<MMovimiento>> ObtenerPorCuenta(int idCuenta);
        Task<int> Insertar(MMovimiento movimiento);
    }
}

using Modelo.Modelos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaz
{
    public interface IUsuario
    {
        Task<List<MUsuario>> ObtenerTodos();

        Task<MUsuario?> ObtenerPorId(int id);

        Task<MUsuario?> ObtenerPorUsuario(string usuario);

        Task<bool> Insertar(MUsuario usuario);

        Task<bool> Actualizar(MUsuario usuario);

        Task<bool> CambiarEstado(int id, bool estado);

        Task<bool> CambiarPassword(int id, string password);

        Task<bool> Eliminar(int id);
    }
}

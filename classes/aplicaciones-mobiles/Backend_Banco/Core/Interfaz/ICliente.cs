using Modelo.Modelos;

namespace Core.Interfaz
{
    public interface ICliente
    {
        Task<List<MCliente>> ObtenerTodos();

        Task<MCliente?> ObtenerPorId(int id);

        Task<bool> Insertar(MCliente cliente);

        Task<bool> Actualizar(MCliente cliente);
    }
}

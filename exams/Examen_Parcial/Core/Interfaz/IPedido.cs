using Modelo.Modelos;

namespace Core.Interfaz
{
    public interface IPedido
    {
        Task<List<MPedido>> ObtenerTodos();

        Task<MPedido?> ObtenerPorId(int id);

        Task<int> Insertar(MPedido pedido);

        Task<bool> Actualizar(MPedido pedido);

        Task<bool> Eliminar(int id);
    }
}

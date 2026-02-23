using Pre_Examen.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Pre_Examen.Interfaz
{
    public interface IServicioInventario
    {
        Task<Producto> BuscarPorId(SqlConnection connection, int id_producto);
        Task<IEnumerable<Producto>> ObtenerProducto(SqlConnection connection);
        Task<Producto> CrearProducto(SqlConnection connection, Producto producto);
    }
}

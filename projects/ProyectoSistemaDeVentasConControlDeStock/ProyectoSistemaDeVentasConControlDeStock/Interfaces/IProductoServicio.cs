using Npgsql;
using ProyectoSistemaDeVentasConControlDeStock.Models;


namespace ProyectoSistemaDeVentasConControlDeStock.Interfaces
{
    public interface IProductoServicio
    {
        public IEnumerable<ProductoModel> TodosLosProductos(NpgsqlConnection connection);

    }
}

using Npgsql;
using Dapper;
using ProyectoSistemaDeVentasConControlDeStock.Models;
using ProyectoSistemaDeVentasConControlDeStock.Interfaces;

namespace ProyectoSistemaDeVentasConControlDeStock.Services
{
    public class ProductoServicio: IProductoServicio
    {
        public IEnumerable<ProductoModel> TodosLosProductos(NpgsqlConnection connection)
        {
            var resultado = connection.QueryAsync<ProductoModel>("select * from productos");
            return resultado.Result;
        }
    }
}

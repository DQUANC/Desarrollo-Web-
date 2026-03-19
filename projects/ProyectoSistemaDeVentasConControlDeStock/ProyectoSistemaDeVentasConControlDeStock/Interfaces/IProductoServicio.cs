using Npgsql;
using ProyectoSistemaDeVentasConControlDeStock.DTOs.ProductosDTOs;
using ProyectoSistemaDeVentasConControlDeStock.Models;

namespace ProyectoSistemaDeVentasConControlDeStock.Interfaces
{
    public interface IProductoServicio
    {
        IEnumerable<ProductoModel> TodosLosProductos(NpgsqlConnection connection);
        Task<ProductoModel?> ObtenerPorId(NpgsqlConnection connection, int sku);
        Task<int> CrearProducto(NpgsqlConnection connection, CrearProductoDTO dto);
        Task<int> ActualizarProducto(NpgsqlConnection connection, ActualizarProductoDTO dto);
        Task<int> EliminarProducto(NpgsqlConnection connection, EliminarProductoDTO dto);
    }
}
using Npgsql;
using Dapper;
using ProyectoSistemaDeVentasConControlDeStock.DTOs.ProductosDTOs;
using ProyectoSistemaDeVentasConControlDeStock.Interfaces;
using ProyectoSistemaDeVentasConControlDeStock.Models;

namespace ProyectoSistemaDeVentasConControlDeStock.Services
{
    public class ProductoServicio : IProductoServicio
    {
        public IEnumerable<ProductoModel> TodosLosProductos(NpgsqlConnection connection)
        {
            var resultado = connection.QueryAsync<ProductoModel>("SELECT * FROM productos");
            return resultado.Result;
        }

        public async Task<ProductoModel?> ObtenerPorId(NpgsqlConnection connection, int sku)
        {
            return await connection.QueryFirstOrDefaultAsync<ProductoModel>(
                "SELECT * FROM productos WHERE sku_producto = @sku",
                new { sku });
        }

        public async Task<int> CrearProducto(NpgsqlConnection connection, CrearProductoDTO dto)
        {
            var query = @"
                INSERT INTO productos (nombre_producto, precio, stock)
                VALUES (@nombre_producto, @precio, @stock)";

            return await connection.ExecuteAsync(query, new
            {
                dto.nombre_producto,
                dto.precio,
                dto.stock
            });
        }

        public async Task<int> ActualizarProducto(NpgsqlConnection connection, ActualizarProductoDTO dto)
        {
            var query = @"
                UPDATE productos
                SET nombre_producto = @nombre_producto,
                    precio          = @precio,
                    stock           = @stock
                WHERE sku_producto = @SKU_producto";

            return await connection.ExecuteAsync(query, new
            {
                dto.nombre_producto,
                dto.precio,
                dto.stock,
                dto.SKU_producto
            });
        }

        public async Task<int> EliminarProducto(NpgsqlConnection connection, EliminarProductoDTO dto)
        {
            var query = "DELETE FROM productos WHERE sku_producto = @SKU_producto";

            return await connection.ExecuteAsync(query, new { dto.SKU_producto });
        }
    }
}
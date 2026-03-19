using Dapper;
using Npgsql;
using ProyectoSistemaDeVentasConControlDeStock.DTOs.VentasDTOs;
using ProyectoSistemaDeVentasConControlDeStock.Interfaces;
using ProyectoSistemaDeVentasConControlDeStock.Models;

namespace ProyectoSistemaDeVentasConControlDeStock.Services
{
    public class VentaServicio : IVentaServicio
    {
        public async Task<(bool exito, string mensaje)> RegistrarVenta(NpgsqlConnection connection, CrearVentaDTO dto)
        {
            // 1. Verificar que el producto existe y obtener su stock actual
            var producto = await connection.QueryFirstOrDefaultAsync<ProductoModel>(
                "SELECT * FROM productos WHERE sku_producto = @sku",
                new { sku = dto.sku_producto });

            if (producto == null)
                return (false, "El producto no existe.");

            // 2. Verificar que hay stock suficiente
            if (producto.stock < dto.cantidad)
                return (false, $"Stock insuficiente. Stock disponible: {producto.stock}.");

            // 3. Registrar la venta (fecha la pone PostgreSQL automáticamente)
            var insertQuery = @"
                INSERT INTO ventas (sku_producto, cantidad)
                VALUES (@sku_producto, @cantidad)";

            await connection.ExecuteAsync(insertQuery, new
            {
                dto.sku_producto,
                dto.cantidad
            });

            // 4. Descontar el stock del producto
            var updateQuery = @"
                UPDATE productos
                SET stock = stock - @cantidad
                WHERE sku_producto = @sku_producto";

            await connection.ExecuteAsync(updateQuery, new
            {
                dto.cantidad,
                dto.sku_producto
            });

            return (true, "Venta registrada correctamente.");
        }

        public async Task<IEnumerable<VentaDetalleDTO>> ObtenerTodasLasVentas(NpgsqlConnection connection)
        {
            var query = @"
                SELECT
                    v.id_venta,
                    p.nombre_producto,
                    p.precio,
                    v.cantidad,
                    (p.precio * v.cantidad) AS total,
                    v.fecha
                FROM ventas v
                INNER JOIN productos p ON v.sku_producto = p.sku_producto
                ORDER BY v.fecha DESC";

            return await connection.QueryAsync<VentaDetalleDTO>(query);
        }
    }
}
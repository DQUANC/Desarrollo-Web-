using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ProyectoSistemaDeVentasConControlDeStock.DTOs.ProductosDTOs;
using ProyectoSistemaDeVentasConControlDeStock.Interfaces;
using ProyectoSistemaDeVentasConControlDeStock.Models;

namespace ProyectoSistemaDeVentasConControlDeStock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IProductoServicio _productoServicio;

        public ProductoController(IConfiguration config, IProductoServicio productoServicio)
        {
            _config = config;
            _productoServicio = productoServicio;
        }

        [HttpGet("ObtenerTodos")]
        public async Task<ActionResult<List<ProductoModel>>> ObtenerTodos()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var productos = _productoServicio.TodosLosProductos(connection);
            return Ok(productos);
        }

        [HttpGet("ObtenerPorId/{sku}")]
        public async Task<ActionResult<ProductoModel>> ObtenerPorId(int sku)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var producto = await _productoServicio.ObtenerPorId(connection, sku);
            if (producto == null) return NotFound(new { mensaje = "Producto no encontrado." });
            return Ok(producto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult> Crear([FromBody] CrearProductoDTO dto)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var filas = await _productoServicio.CrearProducto(connection, dto);
            if (filas == 0) return BadRequest("No se pudo crear el producto.");
            return Ok("Producto creado correctamente.");
        }

        [HttpPut("Actualizar")]
        public async Task<ActionResult> Actualizar([FromBody] ActualizarProductoDTO dto)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var filas = await _productoServicio.ActualizarProducto(connection, dto);
            if (filas == 0) return NotFound("Producto no encontrado.");
            return Ok("Producto actualizado correctamente.");
        }

        [HttpDelete("Eliminar")]
        public async Task<ActionResult> Eliminar([FromBody] EliminarProductoDTO dto)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var filas = await _productoServicio.EliminarProducto(connection, dto);
            if (filas == 0) return NotFound("Producto no encontrado.");
            return Ok("Producto eliminado correctamente.");
        }
    }
}
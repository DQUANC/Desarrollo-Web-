using ProyectoSistemaDeVentasConControlDeStock.Interfaces;
using ProyectoSistemaDeVentasConControlDeStock.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ProyectoSistemaDeVentasConControlDeStock.Controllers
{
    [Produces("applications/json")]
    [Route("api/[controller]")]
    public class ProductoController: Controller
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
    }
}

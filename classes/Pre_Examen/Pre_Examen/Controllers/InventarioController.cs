using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pre_Examen.Interfaz;
using Pre_Examen.Modelos;
using System.Data.SqlClient;
using Pre_Examen.DTOs;
using System.Diagnostics;


namespace Pre_Examen.Controllers
{
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class InventarioController : ControllerBase
        {
            private readonly IConfiguration _config;
            private readonly IServicioInventario _servicioInventario;

            public InventarioController(IConfiguration config, IServicioInventario servicioInventario)
            {
                _config = config;
                _servicioInventario = servicioInventario;
            }

            // GET: api/Producto/obtener-todos
            [HttpGet("obtener-todos")]
            public async Task<ActionResult<IEnumerable<Producto>>> ObtenerTodos()
            {
                using var connection = new SqlConnection(
                    _config.GetConnectionString("DefaultConnection")
                );

                var productos = await _servicioInventario.ObtenerProducto(connection);
                return Ok(productos);
            }

            // GET: api/Producto/obtener-por-id/5
            [HttpGet("obtener-por-id/{id_producto}")]
            public async Task<ActionResult<Producto>> ObtenerPorId(int id_producto)
            {
                using var connection = new SqlConnection(
                    _config.GetConnectionString("DefaultConnection")
                );

                var producto = await _servicioInventario.BuscarPorId(connection, id_producto);

                if (producto == null)
                    return NotFound();

                return Ok(producto);
            }

            // POST: api/Producto/obtener-por-id-body
            [HttpPost("obtener-por-id-body")]
            public async Task<ActionResult<Producto>> ObtenerPorIdBody(
                [FromBody] ProductoPorIdDto dto)
            {
                using var connection = new SqlConnection(
                    _config.GetConnectionString("DefaultConnection")
                );

                var producto = await _servicioInventario.BuscarPorId(connection, dto.id_producto);

                if (producto == null)
                    return NotFound();

                return Ok(producto);
            }

            // POST: api/Productoo/crear-productoo
            [HttpPost("crear-producto")]
            public async Task<ActionResult<Producto>> CrearProducto(
                [FromBody] ProductoCrearPorDto dto)
            {
                using var connection = new SqlConnection(
                    _config.GetConnectionString("DefaultConnection")
                );

                var producto = new Producto
                {
                    nombre = dto.nombre,
                    descripcion = dto.descripcion,
                    precio = dto.precio,
                    stock = dto.stock,
                    fecha_Creacion = dto.fecha_Creacion,
                };

                var creado = await _servicioInventario.CrearProducto(connection, producto);

                return Ok(creado);
            }
        }
}

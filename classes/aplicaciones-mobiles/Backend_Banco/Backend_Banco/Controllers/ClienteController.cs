using Core.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Modelo.Modelos;

namespace Backend_Banco.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    
    public class ClienteController : Controller
    {
        private readonly ICliente _clienteServicio;

        public ClienteController(ICliente clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        // GET api/cliente/ObtenerTodos
        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var clientes = await _clienteServicio.ObtenerTodos();
            return Ok(clientes);
        }

        // GET api/cliente/ObtenerPorId
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cliente = await _clienteServicio.ObtenerPorId(id);
            if(cliente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado. " });
            }
            return Ok(cliente);
        }

        // POST api/cliente
        [HttpPost("Ingresar")]
        public async Task<IActionResult> Insertar([FromBody] MCliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest(new { mensaje = "Los datos del cleinte son obligatorios" });
            }
            if (string.IsNullOrWhiteSpace(cliente.Dpi))
            {
                return BadRequest(new { mensaje = "El DPI es obligatorio" });
            }
            if (string.IsNullOrWhiteSpace(cliente.Nombres))
            {
                return BadRequest(new { mensaje = "El nombre es obligatorio" });
            }
            if (string.IsNullOrWhiteSpace(cliente.Apellidos))
            {
                return BadRequest(new { mensaje = "El Apellido es obligatorio" });
            }
            // faltan validaciones
            bool resultado = await _clienteServicio.Insertar(cliente);
            if (!resultado)
            {
                return StatusCode(500, new
                {
                    mensaje = "No fue posible registrar el cliente."
                });
            }
            return Ok(new {mensaje = "El cliente se registro correctamente."});
        }

        // PUT api/cliente/#
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] MCliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest(new { mensaje = "Los datos del cleinte son obligatorios." });
            }
            var clienteExistente = await _clienteServicio.ObtenerPorId(id);
            if (clienteExistente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado." });
            }
            cliente.IdCliente = id;

            bool resultado = await _clienteServicio.Actualizar(cliente);
            if (!resultado)
            {
                return StatusCode(500, new
                {
                    mensaje = "No fue posible registrar el cliente."
                });
            }
            return Ok(new { mensaje = "El cliente fue actualizado correctamente" });
        }

        // DELETE api/cliente/#
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var clienteExistente = await _clienteServicio.ObtenerPorId(id);
            if (clienteExistente == null)
            {
                return NotFound(new { mensaje = "Cliente no encontrado." });
            }

            bool resultado = await _clienteServicio.Eliminar(id);
            if (!resultado)
            {
                return StatusCode(500, new
                {
                    mensaje = "No fue posible eliminar el cliente."
                });
            }
            return Ok(new { mensaje = "El cliente fue eliminado correctamente." });
        }
    }
}

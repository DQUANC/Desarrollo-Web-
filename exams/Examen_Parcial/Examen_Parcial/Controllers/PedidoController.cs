using Core.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Modelo.Modelos;

namespace Examen_Parcial.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedido _pedidoServicio;

        public PedidoController(IPedido pedidoServicio)
        {
            _pedidoServicio = pedidoServicio;
        }

        // GET api/pedido/ObtenerTodos
        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var pedidos = await _pedidoServicio.ObtenerTodos();
            return Ok(pedidos);
        }

        // GET api/pedido/#
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var pedido = await _pedidoServicio.ObtenerPorId(id);
            if (pedido == null)
            {
                return NotFound(new { mensaje = "Pedido no encontrado." });
            }
            return Ok(pedido);
        }

        // POST api/pedido/Ingresar
        [HttpPost("Ingresar")]
        public async Task<IActionResult> Insertar([FromBody] MPedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest(new { mensaje = "Los datos del pedido son obligatorios." });
            }
            if (string.IsNullOrWhiteSpace(pedido.NumeroPedido))
            {
                return BadRequest(new { mensaje = "El número de pedido es obligatorio." });
            }
            if (string.IsNullOrWhiteSpace(pedido.NombreCliente))
            {
                return BadRequest(new { mensaje = "El nombre del cliente es obligatorio." });
            }
            if (string.IsNullOrWhiteSpace(pedido.DireccionEntrega))
            {
                return BadRequest(new { mensaje = "La dirección de entrega es obligatoria." });
            }
            if (string.IsNullOrWhiteSpace(pedido.Usuario))
            {
                return BadRequest(new { mensaje = "El usuario que registra el pedido es obligatorio." });
            }

            int idPedido = await _pedidoServicio.Insertar(pedido);
            if (idPedido <= 0)
            {
                return StatusCode(500, new
                {
                    mensaje = "No fue posible registrar el pedido."
                });
            }

            return Ok(new
            {
                mensaje = "El pedido se registró correctamente.",
                idPedido = idPedido
            });
        }

        // PUT api/pedido/#
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] MPedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest(new { mensaje = "Los datos del pedido son obligatorios." });
            }

            var pedidoExistente = await _pedidoServicio.ObtenerPorId(id);
            if (pedidoExistente == null)
            {
                return NotFound(new { mensaje = "Pedido no encontrado." });
            }

            pedido.IdPedido = id;

            bool resultado = await _pedidoServicio.Actualizar(pedido);
            if (!resultado)
            {
                return StatusCode(500, new
                {
                    mensaje = "No fue posible actualizar el pedido."
                });
            }

            return Ok(new { mensaje = "El pedido fue actualizado correctamente." });
        }

        // DELETE api/pedido/#
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var pedidoExistente = await _pedidoServicio.ObtenerPorId(id);
            if (pedidoExistente == null)
            {
                return NotFound(new { mensaje = "Pedido no encontrado." });
            }

            bool resultado = await _pedidoServicio.Eliminar(id);
            if (!resultado)
            {
                return StatusCode(500, new
                {
                    mensaje = "No fue posible eliminar el pedido."
                });
            }

            return Ok(new { mensaje = "El pedido fue eliminado correctamente." });
        }
    }
}

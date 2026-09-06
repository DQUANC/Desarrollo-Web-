using Core.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Modelo.Modelos;

namespace Backend_Banco.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class MovimientoController : Controller
    {
        private readonly IMovimiento _movimiento;
        // POST: api/Movimiento
        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] MMovimiento movimiento)
        {
            try
            {
                int idMovimiento = await _movimiento.Insertar(movimiento);

                return Ok(new
                {
                    mensaje = "Movimiento registrado correctamente.",
                    idMovimiento = idMovimiento
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error al registrar el movimiento.",
                    error = ex.Message
                });
            }
        }
    }
}
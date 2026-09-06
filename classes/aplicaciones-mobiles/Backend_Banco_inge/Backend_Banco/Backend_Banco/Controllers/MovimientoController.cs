using Core.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Modelo.Modelos;

namespace Backend_Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : Controller
    {
        private readonly IMovimiento _movimiento;

        public MovimientoController(IMovimiento movimiento)
        {
            _movimiento = movimiento;
        }

        // GET: api/Movimiento
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                var movimientos = await _movimiento.ObtenerTodos();

                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error al obtener los movimientos.",
                    error = ex.Message
                });
            }
        }


        // GET: api/Movimiento/5
        [HttpGet("{idMovimiento}")]
        public async Task<IActionResult> ObtenerPorId(int idMovimiento)
        {
            try
            {
                var movimiento = await _movimiento.ObtenerPorId(idMovimiento);

                if (movimiento == null)
                {
                    return NotFound(new
                    {
                        mensaje = "Movimiento no encontrado."
                    });
                }

                return Ok(movimiento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error al obtener el movimiento.",
                    error = ex.Message
                });
            }
        }


        // GET: api/Movimiento/cuenta/3
        [HttpGet("cuenta/{idCuenta}")]
        public async Task<IActionResult> ObtenerPorCuenta(int idCuenta)
        {
            try
            {
                var movimientos = await _movimiento.ObtenerPorCuenta(idCuenta);

                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error al obtener los movimientos de la cuenta.",
                    error = ex.Message
                });
            }
        }


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

using Examen_Final_DesarrolloWeb1.DTOs;
using Examen_Final_DesarrolloWeb1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_Final_DesarrolloWeb1.Controllers
{
    [ApiController]
    [Route("api/inscripciones")]
    public class InscripcionController : ControllerBase
    {
        private readonly IInscripcionService _inscripcionService;

        public InscripcionController(IInscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inscripciones = await _inscripcionService.GetAllAsync();
            return Ok(inscripciones);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] InscripcionRequestDTO request)
        {
            if (request.codigo_evento <= 0 ||
                request.codigo_persona <= 0 ||
                string.IsNullOrWhiteSpace(request.usuario))
            {
                return BadRequest(new InscripcionResponseDTO
                {
                    exito = false,
                    mensaje = "Todos los campos son requeridos y deben ser válidos."
                });
            }

            var resultado = await _inscripcionService.RegistrarInscripcionAsync(request);

            if (!resultado.exito)
                return BadRequest(resultado);

            return Ok(resultado);
        }
    }
}
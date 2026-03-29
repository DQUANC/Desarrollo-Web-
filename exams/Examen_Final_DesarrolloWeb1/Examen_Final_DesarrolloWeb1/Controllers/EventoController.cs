using Examen_Final_DesarrolloWeb1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_Final_DesarrolloWeb1.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventos = await _eventoService.GetAllAsync();
            return Ok(eventos);
        }
    }
}
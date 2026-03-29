using Examen_Final_DesarrolloWeb1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen_Final_DesarrolloWeb1.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _personaService.GetAllAsync();
            return Ok(personas);
        }
    }
}
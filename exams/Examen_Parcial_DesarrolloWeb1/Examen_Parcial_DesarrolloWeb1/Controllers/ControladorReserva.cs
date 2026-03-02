using Examen_Parcial_DesarrolloWeb1.DTOs;
using Examen_Parcial_DesarrolloWeb1.Interfaz;
using Examen_Parcial_DesarrolloWeb1.Modelos;
using Examen_Parcial_DesarrolloWeb1.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Examen_Parcial_DesarrolloWeb1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ControladorReserva : Controller
    {
        private readonly IConfiguration _config;
        private readonly IReserva _servicioReserva;

        public ControladorReserva(IConfiguration config, IReserva servicioReserva)
        {
            _config = config;
            _servicioReserva = servicioReserva;
        }

        [HttpGet("Obtener Todos")]
        public async Task<ActionResult<List<ModeloReserva>>> ObtenerTodos()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var reservas = _servicioReserva.ObtenerReserva(connection);
            return Ok(reservas);
        }

        [HttpPost("Crear Reserva")]
        public async Task<ActionResult<List<ModeloReserva>>> CrearReserva([FromBody] CrearReservaDTO modelo)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var reservas = _servicioReserva.CrearReserva(connection, modelo);
            return Ok(reservas);
        }

        [HttpPut("Actualizar Reserva")]
        public async Task<ActionResult<List<ModeloReserva>>> ActualizarReserva([FromBody] ActualizarReservaDTO modelo)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var reservas = _servicioReserva.ActualizarReserva(connection, modelo);
            return Ok(reservas);
        }
    }
}

using Clase_7.Interfaz;
using Clase_7.Modelo;
using Microsoft.AspNetCore.Mvc;
using Npgsql;


namespace Clase_7.Controllers
{
    [Produces("applications/json")]
    [Route("api/[controller]")]
    public class ClienteController
    {
        private readonly IConfiguration _config;
        private readonly IClienteServicio _clienteServicio;
        public ClienteController(IConfiguration config, IClienteServicio clienteServicio)
        {
            _config = config;
            _clienteServicio = clienteServicio;
        }


        [HttpGet("ObtenerTodos")]
        public async Task<ActionResult<List<Cliente>>> ObtenerTodos()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var heroes = _clienteServicio.TodosLosClientes(connection);
            return Ok(heroes);
        }
    }
}

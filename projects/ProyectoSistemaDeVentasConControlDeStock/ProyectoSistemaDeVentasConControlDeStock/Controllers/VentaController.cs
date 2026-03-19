using Microsoft.AspNetCore.Mvc;
using Npgsql;
using ProyectoSistemaDeVentasConControlDeStock.DTOs.VentasDTOs;
using ProyectoSistemaDeVentasConControlDeStock.Interfaces;

namespace ProyectoSistemaDeVentasConControlDeStock.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IVentaServicio _ventaServicio;

        public VentaController(IConfiguration config, IVentaServicio ventaServicio)
        {
            _config = config;
            _ventaServicio = ventaServicio;
        }

        [HttpGet("ObtenerTodas")]
        public async Task<ActionResult<IEnumerable<VentaDetalleDTO>>> ObtenerTodas()
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();
            var ventas = await _ventaServicio.ObtenerTodasLasVentas(connection);
            return Ok(ventas);
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar([FromBody] CrearVentaDTO dto)
        {
            using var connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            var (exito, mensaje) = await _ventaServicio.RegistrarVenta(connection, dto);

            if (!exito)
                return BadRequest(new { mensaje });

            return Ok(new { mensaje });
        }
    }
}
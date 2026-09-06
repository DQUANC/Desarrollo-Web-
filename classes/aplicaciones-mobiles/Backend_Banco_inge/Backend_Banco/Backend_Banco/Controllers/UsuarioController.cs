using Core.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Modelo.Modelos;
using Npgsql;

namespace Backend_Banco.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]


    public class UsuarioController : Controller
    {

        private readonly IConfiguration _config;

        private readonly IUsuario _usuarioServicio;
        public UsuarioController(IConfiguration config, IUsuario usuarioServicio)
        {
            _config = config;
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet("ObtenerTodos")]
        public async Task<ActionResult<List<MUsuario>>> ObtenerTodos()
        {
            var usuarios = await _usuarioServicio.ObtenerTodos();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                if (id <= 0) return BadRequest(new { mensaje = "Id inválido." });

                var usuario = await _usuarioServicio.ObtenerPorId(id);

                return usuario == null
                    ? NotFound(new { mensaje = "Usuario no encontrado." })
                    : Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al obtener el usuario.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] MUsuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest(new { mensaje = "Datos inválidos." });

                bool resultado = await _usuarioServicio.Insertar(usuario);

                return resultado
                    ? Ok(new { mensaje = "Usuario insertado correctamente." })
                    : BadRequest(new { mensaje = "No se pudo insertar el usuario." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al insertar el usuario.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] MUsuario usuario)
        {
            try
            {
                usuario.IdUsuario = id;

                bool resultado = await _usuarioServicio.Actualizar(usuario);

                return resultado
                    ? Ok(new { mensaje = "Usuario actualizado correctamente." })
                    : BadRequest(new { mensaje = "No se pudo actualizar el usuario." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al actualizar el usuario.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                bool resultado = await _usuarioServicio.Eliminar(id);

                return resultado
                    ? Ok(new { mensaje = "Usuario eliminado correctamente." })
                    : BadRequest(new { mensaje = "No se pudo eliminar el usuario." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al eliminar el usuario.", error = ex.Message });
            }
        }


        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] bool estado)
        {
            try
            {
                bool resultado = await _usuarioServicio.CambiarEstado(id, estado);

                return resultado
                    ? Ok(new { mensaje = "Estado actualizado correctamente." })
                    : BadRequest(new { mensaje = "No se pudo actualizar el estado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al cambiar el estado.", error = ex.Message });
            }
        }

        [HttpPatch("{id}/password")]
        public async Task<IActionResult> CambiarPassword(int id, [FromBody] string password)
        {
            try
            {
                bool resultado = await _usuarioServicio.CambiarPassword(id, password);

                return resultado
                    ? Ok(new { mensaje = "Contraseña actualizada correctamente." })
                    : BadRequest(new { mensaje = "No se pudo cambiar la contraseña." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al cambiar la contraseña.", error = ex.Message });
            }
        }


        [HttpGet("usuario/{usuario}")]
        public async Task<IActionResult> ObtenerPorUsuario(string usuario)
        {
            try
            {
                var resultado = await _usuarioServicio.ObtenerPorUsuario(usuario);

                return resultado == null
                    ? NotFound(new { mensaje = "Usuario no encontrado." })
                    : Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al buscar el usuario.", error = ex.Message });
            }
        }


    }
}

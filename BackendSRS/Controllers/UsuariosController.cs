using BackendSRS.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackendSRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // Endpoint para GetUsuario
        //[HttpPost("GetUsuario")]
        //public IActionResult GetUsuario([FromBody] string valor, [FromBody] int id)
        //{
        //    var result = _usuariosService.GetUsuario(valor, id);
        //    return Ok(result);
        //}

        [HttpPost("VerificarInicioSesion")]
        public IActionResult VerificarInicioSesion([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { exito = false, mensaje = "Datos de inicio de sesión incompletos." });
            }

            try
            {
                bool resultado = _usuariosService.VerificarInicioSesion(request.Email.ToString(), request.Password.ToString());

                // Supongo que `VerificarInicioSesion` devuelve un booleano o similar.
                // Ajusta según la implementación real de tu servicio.
                if (resultado)
                {
                    return Ok(new { exito = true, mensaje = "Inicio de sesión exitoso." });
                }
                else
                {
                    return Unauthorized(new { exito = false, mensaje = "Credenciales inválidas." });
                }
            }
            catch (Exception ex)
            {
                // En producción, evita devolver detalles de excepciones al cliente.
                return StatusCode(500, new { exito = false, mensaje = "Ocurrió un error en el servidor.", detalle = ex.Message });
            }
        }

        // Endpoint para CreateUsuario
        [HttpPost("CreateUsuario")]
        public IActionResult CreateUsuario([FromBody] JObject data)
        {
            string nombre = data["nombre"]?.ToString() ?? string.Empty;
            string apellido = data["apellido"]?.ToString() ?? string.Empty;
            string email = data["email"]?.ToString() ?? string.Empty;
            string password = data["password"]?.ToString() ?? string.Empty;
            int rolId = data["rolId"] != null ? int.Parse(data["rolId"].ToString()) : 3;
            DateTime fechaRegistro = DateTime.Now;

            var result = _usuariosService.CreateUsuario(nombre, apellido, email, password, rolId, fechaRegistro);
            return Ok(result);
        }

        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            var result = _usuariosService.GetUsuarios();
            return Ok(result);
        }
    }
}

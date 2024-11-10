using BackendSRS.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackendSRS.API.Controllers
{
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        // Endpoint para GetUsuario
        [HttpPost("GetUsuario")]
        public IActionResult GetUsuario([FromBody] string valor, [FromBody] int id)
        {
            var result = _usuariosService.GetUsuario(valor, id);
            return Ok(result);
        }

        // Endpoint para GetAyuda
        [HttpGet("GetAyuda")]
        public IActionResult GetAyuda()
        {
            var result = _usuariosService.GetAyuda();
            return Ok(result);
        }

        // Endpoint para CreateUsuario
        [HttpPost("CreateUsuario")]
        public IActionResult CreateUsuario([FromBody] JObject data)
        {
            string nombre = data["nombre"]?.ToString() ?? string.Empty;
            int edad = data["edad"]?.ToObject<int>() ?? 0;

            var result = _usuariosService.CreateUsuario(nombre, edad);
            return Ok(result);
        }
    }
}

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
        //[HttpPost("GetUsuario")]
        //public IActionResult GetUsuario([FromBody] string valor, [FromBody] int id)
        //{
        //    var result = _usuariosService.GetUsuario(valor, id);
        //    return Ok(result);
        //}

        [HttpGet("VerificaInicioSesion")]
        public string VerificaInicioSesion(string email, string password)
        {
            var result = _usuariosService.VerificarInicioSesion(email, password);
            return result;
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
    }
}

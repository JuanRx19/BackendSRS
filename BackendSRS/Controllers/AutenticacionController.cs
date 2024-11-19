using BackendSRS.Application.Services;
using BackendSRS.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendSRS.Infrastructure.Services;
using BackendSRS.Models;

namespace BackendSRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly IEncriptacionService _encriptacionService;
        private readonly ITokenService _tokenService;
        private readonly UsuariosService _usuariosService;
        private readonly IConfiguration _configuration;

        public AutenticacionController(IEncriptacionService encriptacionService, ITokenService tokenService, UsuariosService userRepository, IConfiguration configuration)
        {
            _encriptacionService = encriptacionService;
            _tokenService = tokenService;
            _usuariosService = userRepository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {

            // Buscar al usuario por username
            var user = _usuariosService.GetUsuarioByEmail(request.Email);
            bool resultado = _usuariosService.VerificarInicioSesion(request.Email.ToString(), request.Password.ToString());

            // Supongo que `VerificarInicioSesion` devuelve un booleano o similar.
            // Ajusta según la implementación real de tu servicio.
            if (!resultado)
            {
                return Unauthorized(new { exito = false, mensaje = "Credenciales inválidas." });
            }

            // Generar el token
            var token = _tokenService.GenerateToken(user.UsuarioId.ToString(), user.Email);

            Response.Cookies.Append("authToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Asegúrate de usar HTTPS
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpirationMinutes"]))
            });

            // Retornar el token
            return Ok(new { exito = true, Message = "Login exitoso" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Eliminar la cookie estableciendo una fecha de expiración pasada
            Response.Cookies.Append("authToken", "", new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(-1),
                HttpOnly = true,
                Secure = true, // Asegúrate de usar HTTPS en producción
                SameSite = SameSiteMode.Strict
            });

            return Ok(new { exito = true, Message = "Logout exitoso" });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using BackendSRS.Application.Services;

namespace BackendSRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly IAlertasService _alertasService;

        public AlertasController(IAlertasService alertasService)
        {
            _alertasService = alertasService;
        }

        [HttpGet("notificaciones")]
        public IActionResult ObtenerAlertas()
        {
            var alertas = _alertasService.ObtenerAlertasCriticas();
            return Ok(alertas);
        }

        [HttpPost("generar")]
        public IActionResult GenerarAlerta([FromBody] Alerta alerta)
        {
            _alertasService.GenerarAlerta(alerta.Mensaje, alerta.Criticidad);
            return Ok("Alerta generada exitosamente.");
        }
    }
}

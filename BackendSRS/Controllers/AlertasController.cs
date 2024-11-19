using BackendSRS.Application.Services;
using BackendSRS.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendSRS.API.Controllers
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

        [HttpGet]
        public IActionResult ObtenerAlertas()
        {
            var alertas = _alertasService.ObtenerAlertas();
            return Ok(alertas);
        }

        [HttpPost]
        public IActionResult GenerarAlerta([FromBody] Alerta alerta)
        {
            _alertasService.GenerarAlerta(alerta.Mensaje, alerta.Criticidad);
            return Ok("Alerta generada exitosamente.");
        }
    }
}

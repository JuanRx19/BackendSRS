using BackendSRS.Application.Services;
using BackendSRS.Domain.Entities.Models;
using BackendSRS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendSRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly AlertasService _alertasService;

        public AlertasController(AlertasService alertasService)
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
        public IActionResult GenerarAlerta([FromBody] Alertas alerta)
        {
            _alertasService.GenerarAlerta(alerta.Mensaje, alerta.Criticidad);
            return Ok("Alerta generada exitosamente.");
        }
        // Endpoint para simular una alerta de bater�a baja
        [HttpPost("bateria")]
        public IActionResult GenerarAlertaBateria([FromBody] BateriaDto bateriaDto)
        {
            _alertasService.GenerarAlertaBateria(bateriaDto.DispositivoId, bateriaDto.PorcentajeBateria);

            // Recuperar las alertas actuales despu�s de generar la nueva alerta
            var alertas = _alertasService.ObtenerAlertas();

            // Devolver las alertas actuales
            return Ok(alertas);
        }



    }
}

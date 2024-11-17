using Microsoft.AspNetCore.Mvc;
using BackendSRS.Application.Services;

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
    public IActionResult ObtenerNotificacionesCriticas()
    {
        var alertas = _alertasService.ObtenerAlertasCriticas();
        return Ok(alertas);
    }
}

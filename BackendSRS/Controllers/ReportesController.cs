using BackendSRS.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendSRS.Models;
using BackendSRS.Domain.Entities.Models;

namespace BackendSRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {

        private readonly ReportesService _reportesService;

        public ReportesController(ReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpGet("ObtenerReportes")]
        public List<ReportesDetalle> ObtenerReportes()
        {
            return _reportesService.ObtenerReportes();
        }
    }
}

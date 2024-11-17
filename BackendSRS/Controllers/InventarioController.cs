using BackendSRS.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackendSRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioService _inventarioService;

        public InventarioController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        // Endpoint para GetUsuario
        //[HttpPost("GetUsuario")]
        //public IActionResult GetUsuario([FromBody] string valor, [FromBody] int id)
        //{
        //    var result = _inventarioService.GetUsuario(valor, id);
        //    return Ok(result);
        //}

        [HttpGet("GetInventario")]
        public IActionResult GetInventario()
        {
            var result = _inventarioService.GetInventario();
            return Ok(result);
        }
    }
}

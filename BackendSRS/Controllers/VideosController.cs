using BackendSRS.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackendSRS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly VideosService _videosService;

        public VideosController(VideosService VideosService)
        {
            _videosService = VideosService;
        }

        // Endpoint para GetUsuario
        //[HttpPost("GetUsuario")]
        //public IActionResult GetUsuario([FromBody] string valor, [FromBody] int id)
        //{
        //    var result = _VideosService.GetUsuario(valor, id);
        //    return Ok(result);
        //}

        [HttpGet("GetVideos")]
        public IActionResult GetVideos()
        {
            var result = _videosService.GetVideos();
            return Ok(result);
        }
    }
}

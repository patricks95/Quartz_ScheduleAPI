using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auto_API_Run.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sampleController : ControllerBase
    {
        [HttpGet("auto-api")]
        public async Task<IActionResult> autoapi()
        {
            return Ok("Received");
        }

    }
}

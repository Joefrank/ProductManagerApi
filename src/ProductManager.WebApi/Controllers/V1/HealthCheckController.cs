using Microsoft.AspNetCore.Mvc;
using ProductManager.Domain.Constants;

namespace ProductManager.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("IsAlive")]
        public IActionResult CheckAppIsAlive()
        {
            return Ok(GenericMessages.AppIsAliveMsg);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NLogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NLogTestController : ControllerBase
    {
        private readonly ILogger<NLogTestController> _logger;

        public NLogTestController(ILogger<NLogTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogError("这是错误信息");
            _logger.LogDebug("这是调试信息");
            _logger.LogInformation("这是提示信息");

            return Ok();
        }
    }
}
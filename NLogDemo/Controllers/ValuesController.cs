using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NLogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Test()
        {
            _logger.LogError("测试封装日志");
            int i = 0;
            int result = 10 / i;
            return Ok();
        }


    }
}
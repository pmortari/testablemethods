using Microsoft.AspNetCore.Mvc;
using TestableMethods.Services.Interfaces;

namespace TestableMethods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestService _testService;

        public TestController(ILogger<TestController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpPut("switches")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PublicLightsSwitch()
        {
            var value = _testService.ChangePublicLightsSwitches();

            var message = $"Current status of public lights switches: {value}. Source: [PublicLightsSwitch] from [Controller]";

            _logger.LogInformation(message);

            return NoContent();
        }

        [HttpPut("switches/{dateTime}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PublicLightsSwitchDaytimeBased(string dateTime)
        {
            var value = _testService.ChangePublicLightsSwitchesBasedOnDayTime(dateTime);

            var message = $"Current status of public lights switches after call using {dateTime} as parameter: {value}. Source: [PublicLightsSwitchDaytimeBased] from [Controller]";

            _logger.LogInformation(message);

            return NoContent();
        }
    }
}
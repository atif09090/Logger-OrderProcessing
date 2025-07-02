using Logger_OrderProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logger_OrderProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegacyLoggerController : ControllerBase
    {
        private readonly ILogger<LegacyLoggerController> _logger;

        public LegacyLoggerController(ILogger<LegacyLoggerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("process")]
        public IActionResult ProcessOrder([FromBody] Order order)
        {
            _logger.LogInformation("Processing order...");
            _logger.LogInformation($"Order details: {order.ProductName}, {order.Amount}, {order.UserEmail}");
            _logger.LogInformation("Order processed successfully.");

            return Ok("Processed");
        }
    }
}

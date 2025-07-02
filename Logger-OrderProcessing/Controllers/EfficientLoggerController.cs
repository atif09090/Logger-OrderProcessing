using Logger_OrderProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logger_OrderProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfficientLoggerController : ControllerBase
    {
        private readonly ILogger<EfficientLoggerController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;

        public EfficientLoggerController(ILogger<EfficientLoggerController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("process")]
        public IActionResult ProcessOrder([FromBody] Order order)
        {
            var correlationId = _contextAccessor.HttpContext?.Items["X-Correlation-ID"]?.ToString() ?? "N/A";

            _logger.LogInformation("Processing order {OrderId} for user {UserId}", order.Id, MaskEmail(order.UserEmail));

            try
            {
                if (order.Amount <= 0)
                {
                    _logger.LogWarning("Invalid amount {Amount} for order {OrderId}", order.Amount, order.Id);
                    return BadRequest("Invalid amount");
                }

                _logger.LogInformation("Order {OrderId} processed at {Time}", order.Id, DateTime.UtcNow);
                return Ok("Processed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing order {OrderId}", order.Id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private string MaskEmail(string email)
        {
            return email.Split('@')[0] + "@***";
        }
    }
}

using FeedbackAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(IConfiguration configuration, ILogger<FeedbackController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SubmitFeedback([FromQuery] int Rate, [FromBody] FeedbackRequest request)
        {
            request.Rate = Rate;

            var systemName = _configuration["SystemSettings:SystemName"];

            _logger.LogInformation("Feedback received from user: {UserName}", request.UserName);

            if (request.Rate < 3)
            {
                _logger.LogWarning("User is not satisfied");
            }

            return Ok($"Feedback received for {systemName}. Thank you, {request.UserName}!");
        }
    }
}
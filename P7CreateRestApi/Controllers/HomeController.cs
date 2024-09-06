using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Get()
        {
            _logger.LogInformation("Acc�s � l'endpoint GET Home pour les r�les Admin, User");
            return Ok("Acc�s autoris� pour Admin et User");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public IActionResult Admin()
        {
            _logger.LogInformation("Acc�s � l'endpoint Admin r�serv� � Admin");
            return Ok("Acc�s autoris� pour Admin uniquement");
        }
    }
}

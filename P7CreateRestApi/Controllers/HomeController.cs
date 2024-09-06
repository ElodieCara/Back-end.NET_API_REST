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
            _logger.LogInformation("Accès à l'endpoint GET Home pour les rôles Admin, User");
            return Ok("Accès autorisé pour Admin et User");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public IActionResult Admin()
        {
            _logger.LogInformation("Accès à l'endpoint Admin réservé à Admin");
            return Ok("Accès autorisé pour Admin uniquement");
        }
    }
}

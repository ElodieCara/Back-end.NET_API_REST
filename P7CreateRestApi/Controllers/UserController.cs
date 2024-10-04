using Dot.Net.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using P7CreateRestApi.Models.DTOs;
using P7CreateRestApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.AddAsync(userDto, userDto.Password);
            if (result == null)
            {
                return BadRequest("User creation failed");
            }

            return Ok(result);
        }

        [HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
{
    var user = await _userService.LoginAsync(loginModel.Username, loginModel.Password);
    if (user == null)
    {
        _logger.LogWarning("Unauthorized login attempt for {Username}", loginModel.Username);
        return Unauthorized();
    }

    return Ok(new
    {
        token = user.Token // Ici tu retournes uniquement le token dans un format simple
    });
}

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedUser = await _userService.UpdateAsync(id, userDto);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            _logger.LogInformation($"Tentative de suppression de l'utilisateur avec ID : {id}");

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"Utilisateur avec ID {id} non trouvé");
                return NotFound();
            }

            await _userService.DeleteAsync(id);
            _logger.LogInformation($"Utilisateur avec ID {id} supprimé avec succès");
            return NoContent();
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}

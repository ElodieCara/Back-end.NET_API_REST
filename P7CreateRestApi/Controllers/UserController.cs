using Dot.Net.WebApi.Models;
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

        // Méthode d'enregistrement (register)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            var result = await _userService.AddAsync(userModel, userModel.Password);
            if (result == null)
            {
                _logger.LogError("User creation failed for {Username}", userModel.Username);
                return BadRequest("User creation failed");
            }

            return Ok(result);
        }

        // Méthode de connexion (login)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userService.LoginAsync(loginModel.Username, loginModel.Password);
            if (user == null)
            {
                _logger.LogWarning("Unauthorized login attempt for {Username}", loginModel.Username);
                return Unauthorized();
            }

            var userOutputDto = new UserOutputDto
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname,
                Role = user.Role,
                Token = user.Token 
            };

            return Ok(userOutputDto);
        }

        // Suppression de l'utilisateur
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);
            return NoContent();
        }

        // Méthode pour anonymiser les données utilisateur
        [Authorize]
        [HttpPut("anonymize/{id}")]
        public async Task<IActionResult> AnonymizeUser(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Fullname = "Anonymous";
            user.Username = "anonymous_user";

            await _userService.UpdateAsync(id, user);
            return Ok();
        }

        // Récupérer tous les utilisateurs
        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // Récupérer un utilisateur par ID
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userOutputDto = new UserOutputDto
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname,
                Role = user.Role
            };

            return Ok(userOutputDto);
        }

        // Mise à jour de l'utilisateur
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserModel userModel)
        {
            var updatedUser = await _userService.UpdateAsync(id, userModel);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }
    }
}

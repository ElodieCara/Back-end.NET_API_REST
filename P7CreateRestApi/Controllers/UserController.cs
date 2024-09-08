using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using P7CreateRestApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

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
        public async Task<IActionResult> Register([FromBody] UserModel userDto, string password)
        {
            var result = await _userService.AddAsync(userDto, password);
            if (result == null)
            {
                _logger.LogError("User creation failed for {Username}", userDto.Username);
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

            return Ok(user);
        }

        // Suppression de l'utilisateur (Droit à l'oubli)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);  // Suppression des données
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

            // Anonymisation des données
            user.Fullname = "Anonymous";
            user.Username = "anonymous_user";
            // Ajoute d'autres propriétés à anonymiser si nécessaire

            await _userService.UpdateAsync(id, user);
            return Ok();
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserModel userDto)
        {
            var updatedUser = await _userService.UpdateAsync(id, userDto);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}

using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using System.Collections.Generic;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        // Authentification
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDto)
        {
            var user = await _authService.Authenticate(userDto.Username, userDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {
            try
            {
                var user = await _authService.Register(userDto);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Gestion des utilisateurs
        [HttpGet("list")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.AddAsync(user);
            return Ok(user);
        }

        [HttpGet("validate")]
        public async Task<IActionResult> Validate([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.AddAsync(user);
            return Ok(user);
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> ShowUpdateForm(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Invalid user Id: {id}");
            }

            return Ok(user);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User with Id: {id} not found");
            }

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.Fullname = user.Fullname;
            existingUser.Role = user.Role;

            await _userRepository.UpdateAsync(existingUser);
            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with Id: {id} not found");
            }

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("/secure/article-details")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
    }
}

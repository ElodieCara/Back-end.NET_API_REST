using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Models.DTOs;
using System.Text;
using System;
using System.Security.Claims;

namespace Dot.Net.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager, ILogger<UserService> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = _userManager.Users;
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.UserName,
                Fullname = u.Fullname,
                Role = u.Role
            });
        }

        public async Task<UserDto> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var tokenString = GenerateJwtToken(user);

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Fullname = user.Fullname,
                    Role = user.Role,
                    Token = tokenString
                };
            }
            return null;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Fullname = user.Fullname,
                Role = user.Role
            };
        }

        public async Task<UserDto> AddAsync(UserDto dto, string password)
        {
            var user = new User
            {
                UserName = dto.Username,
                Fullname = dto.Fullname,
                Role = dto.Role
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError("Error creating user: {Error}", error.Description);
                }
                throw new Exception("User creation failed.");
            }

            await _userManager.AddToRoleAsync(user, dto.Role);

            var tokenString = GenerateJwtToken(user);

            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Fullname = user.Fullname,
                Role = user.Role,
                Token = tokenString
            };
        }

        public async Task<UserDto> UpdateAsync(string id, UserDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.UserName = dto.Username;
            user.Fullname = dto.Fullname;
            user.Role = dto.Role;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError("Error updating user: {Error}", error.Description);
                }
                throw new Exception("User update failed.");
            }

            return new UserDto
            {               
                Username = user.UserName,
                Fullname = user.Fullname,
                Role = user.Role
            };
        }
        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found.", id); // Log si l'utilisateur n'est pas trouvé
                throw new Exception("User not found.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError("Error deleting user: {Error}", error.Description);
                }
                throw new Exception("User deletion failed.");
            }

            _logger.LogInformation("User with ID {UserId} successfully deleted.", id); // Log succès
        }


        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.Role) // Rôle dans le token
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

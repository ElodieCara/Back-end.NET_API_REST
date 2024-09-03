using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Models;
using Microsoft.AspNetCore.Identity;

namespace Dot.Net.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = _userManager.Users;
            return users.Select(u => new UserModel
            {
                Id = u.Id,
                Username = u.UserName,
                Fullname = u.Fullname, // Ajouter Fullname
                Role = u.Role // Ajouter Role
            });
        }

        public async Task<UserModel> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null!;

            return new UserModel
            {
                Id = user.Id,
                Username = user.UserName,
                Fullname = user.Fullname, // Ajouter Fullname
                Role = user.Role // Ajouter Role
            };
        }

        public async Task<UserModel> AddAsync(UserModel dto, string password)
        {
            var user = new User
            {
                UserName = dto.Username,
                Email = dto.Username,
                Fullname = dto.Fullname,
                Role = dto.Role
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed.");
            }

            await _userManager.AddToRoleAsync(user, dto.Role);

            dto.Id = user.Id;
            return dto;
        }
               

        public async Task<UserModel> UpdateAsync(string id, UserModel dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null!;

            user.UserName = dto.Username;
            user.Email = dto.Username;
            user.Fullname = dto.Fullname; // Ajouter Fullname
            user.Role = dto.Role; // Ajouter Role

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("User update failed.");
            }

            return dto;
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
    }
}

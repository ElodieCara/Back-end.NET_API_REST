using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;

namespace Dot.Net.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Fullname = u.Fullname,
                Role = u.Role
            });
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null!;

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Fullname = user.Fullname,
                Role = user.Role
            };
        }

        public async Task<UserDTO> AddAsync(UserDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Fullname = dto.Fullname,
                Role = dto.Role,
                Password = "defaultpassword" // Placeholder for now
            };
            await _repository.AddAsync(user);
            dto.Id = user.Id;
            return dto;
        }

        public async Task<UserDTO> UpdateAsync(int id, UserDTO dto)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null!;

            user.Username = dto.Username;
            user.Fullname = dto.Fullname;
            user.Role = dto.Role;

            await _repository.UpdateAsync(user);

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

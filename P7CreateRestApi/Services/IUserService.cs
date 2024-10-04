using System.Collections.Generic;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;

namespace Dot.Net.WebApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> LoginAsync(string username, string password);
        Task<UserDto> GetByIdAsync(string id);
        Task<UserDto> AddAsync(UserDto dto, string password);
        Task<UserDto> UpdateAsync(string id, UserDto dto);
        Task DeleteAsync(string id);
    }
}

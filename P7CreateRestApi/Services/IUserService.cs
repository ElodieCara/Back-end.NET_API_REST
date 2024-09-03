using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(string id);
        Task<UserModel> AddAsync(UserModel dto, string password);
        Task<UserModel> UpdateAsync(string id, UserModel dto);
        Task DeleteAsync(string id);
    }
}

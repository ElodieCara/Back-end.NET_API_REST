using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dot.Net.WebApi.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetByUsernameAsync(string username);
        Task<IEnumerable<IdentityUser>> GetAllAsync();
        Task<IdentityUser> GetByIdAsync(string id);
        Task AddAsync(IdentityUser entity, string password);
        Task UpdateAsync(IdentityUser entity);
        Task DeleteAsync(string id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Repositories
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetAllAsync();
        Task<Rating> GetByIdAsync(int id);
        Task AddAsync(Rating entity);
        Task UpdateAsync(Rating entity);
        Task DeleteAsync(int id);
    }
}

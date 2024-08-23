using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Repositories
{
    public interface IRuleNameRepository
    {
        Task<IEnumerable<RuleName>> GetAllAsync();
        Task<RuleName> GetByIdAsync(int id);
        Task AddAsync(RuleName entity);
        Task UpdateAsync(RuleName entity);
        Task DeleteAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IRuleNameService
    {
        Task<IEnumerable<RuleNameModel>> GetAllAsync();
        Task<RuleNameModel> GetByIdAsync(int id);
        Task<RuleNameModel> AddAsync(RuleNameModel dto);
        Task<RuleNameModel> UpdateAsync(int id, RuleNameModel dto);
        Task DeleteAsync(int id);
    }
}

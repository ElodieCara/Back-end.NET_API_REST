using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IRuleNameService
    {
        Task<IEnumerable<RuleNameDTO>> GetAllAsync();
        Task<RuleNameDTO> GetByIdAsync(int id);
        Task<RuleNameDTO> AddAsync(RuleNameDTO dto);
        Task<RuleNameDTO> UpdateAsync(int id, RuleNameDTO dto);
        Task DeleteAsync(int id);
    }
}

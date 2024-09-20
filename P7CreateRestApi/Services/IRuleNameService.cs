using System.Collections.Generic;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;

namespace Dot.Net.WebApi.Services
{
    public interface IRuleNameService
    {
        Task<IEnumerable<RuleNameDto>> GetAllAsync();
        Task<RuleNameDto> GetByIdAsync(int id);
        Task<RuleNameDto> AddAsync(RuleNameDto dto);
        Task<RuleNameDto> UpdateAsync(int id, RuleNameDto dto);
        Task DeleteAsync(int id);
    }
}

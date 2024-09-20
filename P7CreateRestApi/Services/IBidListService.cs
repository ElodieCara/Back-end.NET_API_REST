using System.Collections.Generic;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;

namespace Dot.Net.WebApi.Services
{
    public interface IBidListService
    {
        Task<IEnumerable<BidListDto>> GetAllAsync();
        Task<BidListDto> GetByIdAsync(int id);
        Task<BidListDto> AddAsync(BidListDto dto);
        Task<BidListDto> UpdateAsync(int id, BidListDto dto);
        Task DeleteAsync(int id);
    }
}

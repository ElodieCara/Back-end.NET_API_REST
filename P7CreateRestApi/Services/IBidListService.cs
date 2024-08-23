using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IBidListService
    {
        Task<IEnumerable<BidListDTO>> GetAllAsync();
        Task<BidListDTO> GetByIdAsync(int id);
        Task<BidListDTO> AddAsync(BidListDTO dto);
        Task<BidListDTO> UpdateAsync(int id, BidListDTO dto);
        Task DeleteAsync(int id);
    }
}

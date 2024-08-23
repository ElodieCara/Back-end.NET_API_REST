using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface ITradeService
    {
        Task<IEnumerable<TradeDTO>> GetAllAsync();
        Task<TradeDTO> GetByIdAsync(int id);
        Task<TradeDTO> AddAsync(TradeDTO dto);
        Task<TradeDTO> UpdateAsync(int id, TradeDTO dto);
        Task DeleteAsync(int id);
    }
}

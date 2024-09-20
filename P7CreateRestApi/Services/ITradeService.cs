using System.Collections.Generic;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;

namespace Dot.Net.WebApi.Services
{
    public interface ITradeService
    {
        Task<IEnumerable<TradeDto>> GetAllAsync();
        Task<TradeDto> GetByIdAsync(int id);
        Task<TradeDto> AddAsync(TradeDto dto);
        Task<TradeDto> UpdateAsync(int id, TradeDto dto);
        Task DeleteAsync(int id);

        // Nouvelle méthode pour récupérer les trades par userId
        Task<IEnumerable<TradeDto>> GetTradesByUserIdAsync(string userId);
    }
}

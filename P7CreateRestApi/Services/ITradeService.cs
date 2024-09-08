using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface ITradeService
    {
        Task<IEnumerable<TradeModel>> GetAllAsync();
        Task<TradeModel> GetByIdAsync(int id);
        Task<TradeModel> AddAsync(TradeModel dto);
        Task<TradeModel> UpdateAsync(int id, TradeModel dto);
        Task DeleteAsync(int id);

        // Nouvelle méthode pour récupérer les trades par userId
        Task<IEnumerable<TradeModel>> GetTradesByUserIdAsync(string userId);
    }
}

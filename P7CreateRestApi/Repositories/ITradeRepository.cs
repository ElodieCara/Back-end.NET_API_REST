using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Repositories
{
    public interface ITradeRepository
    {
        Task<IEnumerable<Trade>> GetAllAsync();
        Task<Trade> GetByIdAsync(int id);
        Task AddAsync(Trade entity);
        Task UpdateAsync(Trade entity);
        Task DeleteAsync(int id);
        // Nouvelle méthode pour récupérer les trades d'un utilisateur
        Task<IEnumerable<Trade>> GetTradesByUserIdAsync(string userId);
    }
}

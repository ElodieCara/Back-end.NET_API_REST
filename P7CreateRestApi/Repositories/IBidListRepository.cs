using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;


namespace Dot.Net.WebApi.Repositories
{
    public interface IBidListRepository
    {
        Task<BidList> GetByIdAsync(int id);
        Task<IEnumerable<BidList>> GetAllAsync();
        Task AddAsync(BidList bidList);
        Task UpdateAsync(BidList bidList);
        Task DeleteAsync(int id);
    }
}

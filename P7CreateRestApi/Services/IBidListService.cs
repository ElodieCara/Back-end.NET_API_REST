using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IBidListService
    {
        Task<IEnumerable<BidListModel>> GetAllAsync();
        Task<BidListModel> GetByIdAsync(int id);
        Task<BidListModel> AddAsync(BidListModel dto);
        Task<BidListModel> UpdateAsync(int id, BidListModel dto);
        Task DeleteAsync(int id);
    }
}

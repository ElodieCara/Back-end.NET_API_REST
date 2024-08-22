using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;



namespace Dot.Net.WebApi.Services {
    public interface IBidListService
    {
        Task<BidList> GetBidByIdAsync(int id);
        Task<IEnumerable<BidList>> GetAllBidsAsync();
        Task AddBidAsync(BidList bidList);
        Task UpdateBidAsync(int id, BidList bidList);
        Task DeleteBidAsync(int id);
        Task ValidateBidAsync(BidList bidList);
    }
 }
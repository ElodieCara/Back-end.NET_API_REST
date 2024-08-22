using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;


namespace Dot.Net.WebApi.Repositories 
{
    public class BidListRepository : IBidListRepository
    {
        private readonly LocalDbContext _context;

        public BidListRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<BidList> GetByIdAsync(int id)
        {
            return await _context.Bids.FindAsync(id);
        }

        public async Task<IEnumerable<BidList>> GetAllAsync()
        {
            return await _context.Bids.ToListAsync();
        }

        public async Task AddAsync(BidList bidList)
        {
            await _context.Bids.AddAsync(bidList);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(BidList bidList)
        {
            _context.Bids.Update(bidList);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var bidList = await GetByIdAsync(id);
            if (bidList != null)
            {
                _context.Bids.Remove(bidList);
                await _context.SaveChangesAsync(); 
            }
        }
    }
}

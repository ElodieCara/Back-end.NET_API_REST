using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dot.Net.WebApi.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        private readonly LocalDbContext _context;

        public TradeRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trade>> GetAllAsync()
        {
            return await _context.Trades.ToListAsync();
        }

        public async Task<Trade> GetByIdAsync(int id)
        {
            return await _context.Trades.FindAsync(id);
        }

        public async Task AddAsync(Trade trade)
        {
            await _context.Trades.AddAsync(trade);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trade trade)
        {
            _context.Trades.Update(trade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var trade = await GetByIdAsync(id);
            if (trade != null)
            {
                _context.Trades.Remove(trade);
                await _context.SaveChangesAsync();
            }
        }
    }
}

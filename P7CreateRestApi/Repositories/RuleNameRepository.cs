using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dot.Net.WebApi.Repositories
{
    public class RuleNameRepository : IRuleNameRepository
    {
        private readonly LocalDbContext _context;

        public RuleNameRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RuleName>> GetAllAsync()
        {
            return await _context.RuleNames.ToListAsync();
        }

        public async Task<RuleName> GetByIdAsync(int id)
        {
            return await _context.RuleNames.FindAsync(id);
        }

        public async Task AddAsync(RuleName ruleName)
        {
            await _context.RuleNames.AddAsync(ruleName);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RuleName ruleName)
        {
            _context.RuleNames.Update(ruleName);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ruleName = await GetByIdAsync(id);
            if (ruleName != null)
            {
                _context.RuleNames.Remove(ruleName);
                await _context.SaveChangesAsync();
            }
        }
    }
}

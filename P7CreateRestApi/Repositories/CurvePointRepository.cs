using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Repositories;

namespace Dot.Net.WebApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
    {
        private readonly LocalDbContext _context;

        public CurvePointRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CurvePoint curvePoint)
        {
            await _context.CurvePoints.AddAsync(curvePoint);
            await _context.SaveChangesAsync();
        }

        public async Task<CurvePoint> GetByIdAsync(int id)
        {
            return await _context.CurvePoints.FindAsync(id);
        }

        public async Task<IEnumerable<CurvePoint>> GetAllAsync()
        {
            return await _context.CurvePoints.ToListAsync();
        }

        public async Task UpdateAsync(CurvePoint curvePoint)
        {
            _context.CurvePoints.Update(curvePoint);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var curvePoint = await _context.CurvePoints.FindAsync(id);
            if (curvePoint != null)
            {
                _context.CurvePoints.Remove(curvePoint);
                await _context.SaveChangesAsync();
            }
        }
    }
}

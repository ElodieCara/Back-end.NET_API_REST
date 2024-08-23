using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Repositories
{
    public interface ICurvePointRepository
    {
        Task<IEnumerable<CurvePoint>> GetAllAsync();
        Task<CurvePoint> GetByIdAsync(int id);
        Task AddAsync(CurvePoint entity);
        Task UpdateAsync(CurvePoint entity);
        Task DeleteAsync(int id);
    }
}

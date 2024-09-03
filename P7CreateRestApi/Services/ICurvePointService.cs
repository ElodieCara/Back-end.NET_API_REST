using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface ICurvePointService
    {
        Task<IEnumerable<CurvePointModel>> GetAllAsync();
        Task<CurvePointModel> GetByIdAsync(int id);
        Task<CurvePointModel> AddAsync(CurvePointModel dto);
        Task<CurvePointModel> UpdateAsync(int id, CurvePointModel dto);
        Task DeleteAsync(int id);
    }
}

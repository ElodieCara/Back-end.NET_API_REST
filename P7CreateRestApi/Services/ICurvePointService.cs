using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface ICurvePointService
    {
        Task<IEnumerable<CurvePointDTO>> GetAllAsync();
        Task<CurvePointDTO> GetByIdAsync(int id);
        Task<CurvePointDTO> AddAsync(CurvePointDTO dto);
        Task<CurvePointDTO> UpdateAsync(int id, CurvePointDTO dto);
        Task DeleteAsync(int id);
    }
}

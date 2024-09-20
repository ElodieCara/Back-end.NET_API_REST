using System.Collections.Generic;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;

namespace Dot.Net.WebApi.Services
{
    public interface ICurvePointService
    {
        Task<IEnumerable<CurvePointDto>> GetAllAsync();
        Task<CurvePointDto> GetByIdAsync(int id);
        Task<CurvePointDto> AddAsync(CurvePointDto dto);
        Task<CurvePointDto> UpdateAsync(int id, CurvePointDto dto);
        Task DeleteAsync(int id);
    }
}

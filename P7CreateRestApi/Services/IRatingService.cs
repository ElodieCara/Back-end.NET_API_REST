using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingDTO>> GetAllAsync();
        Task<RatingDTO> GetByIdAsync(int id);
        Task<RatingDTO> AddAsync(RatingDTO dto);
        Task<RatingDTO> UpdateAsync(int id, RatingDTO dto);
        Task DeleteAsync(int id);
    }
}

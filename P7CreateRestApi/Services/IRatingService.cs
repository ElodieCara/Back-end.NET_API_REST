using System.Collections.Generic;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Services
{
    public interface IRatingService
    {
        Task<IEnumerable<RatingModel>> GetAllAsync();
        Task<RatingModel> GetByIdAsync(int id);
        Task<RatingModel> AddAsync(RatingModel dto);
        Task<RatingModel> UpdateAsync(int id, RatingModel dto);
        Task DeleteAsync(int id);
    }
}

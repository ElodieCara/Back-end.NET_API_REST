using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;

namespace Dot.Net.WebApi.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _repository;

        public RatingService(IRatingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RatingModel>> GetAllAsync()
        {
            var ratings = await _repository.GetAllAsync();
            // Convertir la liste de Rating en RatingModel pour la couche service
            return ratings.Select(r => new RatingModel
            {
                Id = r.Id,
                MoodysRating = r.MoodysRating,
                SandPRating = r.SandPRating,
                FitchRating = r.FitchRating,
                OrderNumber = r.OrderNumber
            });
        }

        public async Task<RatingModel> GetByIdAsync(int id)
        {
            var rating = await _repository.GetByIdAsync(id);
            if (rating == null)
            {
                return null!;
            }

            // Convertir Rating en RatingModel
            return new RatingModel
            {
                Id = rating.Id,
                MoodysRating = rating.MoodysRating,
                SandPRating = rating.SandPRating,
                FitchRating = rating.FitchRating,
                OrderNumber = rating.OrderNumber
            };
        }

        public async Task<RatingModel> AddAsync(RatingModel dto)
        {
            // Convertir RatingModel en Rating pour le stockage
            var rating = new Rating
            {
                MoodysRating = dto.MoodysRating,
                SandPRating = dto.SandPRating,
                FitchRating = dto.FitchRating,
                OrderNumber = dto.OrderNumber
            };
            await _repository.AddAsync(rating);
            dto.Id = rating.Id;
            return dto;
        }

        public async Task<RatingModel> UpdateAsync(int id, RatingModel dto)
        {
            var rating = await _repository.GetByIdAsync(id);
            if (rating == null)
            {
                return null!;
            }

            // Mise à jour des propriétés de l'entité Rating
            rating.MoodysRating = dto.MoodysRating;
            rating.SandPRating = dto.SandPRating;
            rating.FitchRating = dto.FitchRating;
            rating.OrderNumber = dto.OrderNumber;

            await _repository.UpdateAsync(rating);

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using P7CreateRestApi.Models.DTOs;
using System.Linq;
using Dot.Net.WebApi.Models;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;
        private readonly ILogger<RatingController> _logger;

        public RatingController(IRatingService service, ILogger<RatingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<RatingDto>>> GetAllRatings()
        {
            _logger.LogInformation("Fetching all ratings.");
            var ratings = await _service.GetAllAsync();

            var ratingDtos = ratings.Select(rating => new RatingDto
            {
                Id = rating.Id,
                MoodysRating = rating.MoodysRating,
                SandPRating = rating.SandPRating,
                FitchRating = rating.FitchRating,
                OrderNumber = rating.OrderNumber
            }).ToList();

            return Ok(new { Message = "All ratings fetched successfully.", Data = ratingDtos });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<RatingDto>> GetRating(int id)
        {
            _logger.LogInformation("Fetching rating with ID: {RatingId}", id);
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                _logger.LogWarning("Rating with ID: {RatingId} not found.", id);
                return NotFound(new { Message = $"Rating with ID {id} not found." });
            }

            var ratingDto = new RatingDto
            {
                Id = rating.Id,
                MoodysRating = rating.MoodysRating,
                SandPRating = rating.SandPRating,
                FitchRating = rating.FitchRating,
                OrderNumber = rating.OrderNumber
            };

            return Ok(new { Message = $"Rating with ID {id} fetched successfully.", Data = ratingDto });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RatingDto>> AddRating([FromBody] RatingModel ratingModel)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding new rating.");

                var newRating = await _service.AddAsync(ratingModel);

                var ratingOutputDto = new RatingDto
                {
                    Id = newRating.Id,
                    MoodysRating = newRating.MoodysRating,
                    SandPRating = newRating.SandPRating,
                    FitchRating = newRating.FitchRating,
                    OrderNumber = newRating.OrderNumber
                };

                return CreatedAtAction(nameof(GetRating), new { id = ratingOutputDto.Id }, new { Message = "Rating created successfully.", Data = ratingOutputDto });
            }

            _logger.LogError("Invalid model state while adding a rating.");
            return BadRequest(new { Message = "Invalid model state.", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRating(int id, [FromBody] RatingModel ratingModel)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Updating rating with ID: {RatingId}", id);

                var updatedRating = await _service.UpdateAsync(id, ratingModel);
                if (updatedRating == null)
                {
                    _logger.LogWarning("Rating with ID: {RatingId} not found for update.", id);
                    return NotFound(new { Message = $"Rating with ID {id} not found for update." });
                }

                _logger.LogInformation("Rating with ID: {RatingId} updated successfully.", id);
                return Ok(new { Message = $"Rating with ID {id} updated successfully.", Data = updatedRating });
            }

            _logger.LogError("Invalid model state while updating rating with ID: {RatingId}", id);
            return BadRequest(new { Message = "Invalid model state.", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            _logger.LogInformation("Deleting rating with ID: {RatingId}", id);
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                _logger.LogWarning("Rating with ID: {RatingId} not found for deletion.", id);
                return NotFound(new { Message = $"Rating with ID {id} not found for deletion." });
            }

            await _service.DeleteAsync(id);
            _logger.LogInformation("Rating with ID: {RatingId} deleted successfully.", id);
            return Ok(new { Message = $"Rating with ID {id} deleted successfully." });
        }
    }
}

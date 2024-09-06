using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

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
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetAllRatings()
        {
            _logger.LogInformation("Fetching all ratings.");
            var ratings = await _service.GetAllAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<RatingModel>> GetRating(int id)
        {
            _logger.LogInformation("Fetching rating with ID: {RatingId}", id);
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                _logger.LogWarning("Rating with ID: {RatingId} not found.", id);
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RatingModel>> AddRating(RatingModel ratingDTO)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding new rating.");
                var newRating = await _service.AddAsync(ratingDTO);
                return CreatedAtAction(nameof(GetRating), new { id = newRating.Id }, newRating);
            }
            _logger.LogError("Invalid model state while adding a rating.");
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRating(int id, RatingModel ratingDTO)
        {
            if (id != ratingDTO.Id)
            {
                _logger.LogWarning("Rating ID mismatch: {RatingId}", id);
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Updating rating with ID: {RatingId}", id);
                var updatedRating = await _service.UpdateAsync(id, ratingDTO);
                if (updatedRating == null)
                {
                    _logger.LogWarning("Rating with ID: {RatingId} not found for update.", id);
                    return NotFound();
                }
                return NoContent();
            }
            _logger.LogError("Invalid model state while updating rating with ID: {RatingId}", id);
            return BadRequest(ModelState);
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
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

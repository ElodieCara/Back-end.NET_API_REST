using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDTO>>> GetAllRatings()
        {
            var ratings = await _service.GetAllAsync();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RatingDTO>> GetRating(int id)
        {
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult<RatingDTO>> AddRating(RatingDTO ratingDTO)
        {
            if (ModelState.IsValid)
            {
                var newRating = await _service.AddAsync(ratingDTO);
                return CreatedAtAction(nameof(GetRating), new { id = newRating.Id }, newRating);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(int id, RatingDTO ratingDTO)
        {
            if (id != ratingDTO.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedRating = await _service.UpdateAsync(id, ratingDTO);
                if (updatedRating == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            var rating = await _service.GetByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

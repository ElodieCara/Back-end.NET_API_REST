using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Microsoft.Extensions.Logging;
using P7CreateRestApi.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurvePointController : ControllerBase
    {
        private readonly ICurvePointService _service;
        private readonly ILogger<CurvePointController> _logger;

        public CurvePointController(ICurvePointService service, ILogger<CurvePointController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<CurvePointDto>>> GetAllCurvePoints()
        {
            _logger.LogInformation("Fetching all curve points.");
            var curvePoints = await _service.GetAllAsync();
            return Ok(new { Message = "All curve points fetched successfully.", Data = curvePoints });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<CurvePointDto>> GetCurvePoint(int id)
        {
            _logger.LogInformation("Fetching curve point with ID: {id}", id);
            var curvePoint = await _service.GetByIdAsync(id);
            if (curvePoint == null)
            {
                _logger.LogWarning("Curve point with ID: {id} not found", id);
                return NotFound(new { Message = $"Curve point with ID {id} not found." });
            }
            return Ok(new { Message = $"Curve point with ID {id} fetched successfully.", Data = curvePoint });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CurvePointDto>> AddCurvePoint([FromBody] CurvePointDto curvePointDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding new curve point.");
                var newCurvePoint = await _service.AddAsync(curvePointDto);
                return CreatedAtAction(nameof(GetCurvePoint), new { id = newCurvePoint.Id }, new { Message = "Curve point created successfully.", Data = newCurvePoint });
            }

            _logger.LogError("Invalid model state while adding a curve point.");
            return BadRequest(new { Message = "Invalid model state.", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCurvePoint(int id, [FromBody] CurvePointDto curvePointDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Updating curve point with ID: {id}", id);
                var updatedCurvePoint = await _service.UpdateAsync(id, curvePointDto);
                if (updatedCurvePoint == null)
                {
                    _logger.LogWarning("Curve point with ID: {id} not found for update", id);
                    return NotFound(new { Message = $"Curve point with ID {id} not found for update." });
                }
                _logger.LogInformation("Curve point with ID: {id} updated successfully.", id);
                return Ok(new { Message = $"Curve point with ID {id} updated successfully.", Data = updatedCurvePoint });
            }

            _logger.LogError("Invalid model state while updating a curve point.");
            return BadRequest(new { Message = "Invalid model state.", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            _logger.LogInformation("Deleting curve point with ID: {id}", id);
            var curvePoint = await _service.GetByIdAsync(id);
            if (curvePoint == null)
            {
                _logger.LogWarning("Curve point with ID: {id} not found for deletion", id);
                return NotFound(new { Message = $"Curve point with ID {id} not found for deletion." });
            }

            await _service.DeleteAsync(id);
            _logger.LogInformation("Curve point with ID: {id} deleted successfully.", id);
            return Ok(new { Message = $"Curve point with ID {id} deleted successfully." });
        }
    }
}

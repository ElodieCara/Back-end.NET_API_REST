using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurveController : ControllerBase
    {
        private readonly ICurvePointService _service;

        public CurveController(ICurvePointService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<CurvePointModel>>> GetAllCurvePoints()
        {
            var curvePoints = await _service.GetAllAsync();
            return Ok(curvePoints);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<CurvePointModel>> GetCurvePoint(int id)
        {
            var curvePoint = await _service.GetByIdAsync(id);
            if (curvePoint == null)
            {
                return NotFound();
            }
            return Ok(curvePoint);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CurvePointModel>> AddCurvePoint(CurvePointModel curvePointDTO)
        {
            if (ModelState.IsValid)
            {
                var newCurvePoint = await _service.AddAsync(curvePointDTO);
                return CreatedAtAction(nameof(GetCurvePoint), new { id = newCurvePoint.Id }, newCurvePoint);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCurvePoint(int id, CurvePointModel curvePointDTO)
        {
            if (id != curvePointDTO.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedCurvePoint = await _service.UpdateAsync(id, curvePointDTO);
                if (updatedCurvePoint == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            var curvePoint = await _service.GetByIdAsync(id);
            if (curvePoint == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

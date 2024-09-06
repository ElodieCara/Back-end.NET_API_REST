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
    public class CurveController : ControllerBase
    {
        private readonly ICurvePointService _service;
        private readonly ILogger<CurveController> _logger;

        public CurveController(ICurvePointService service, ILogger<CurveController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<CurvePointModel>>> GetAllCurvePoints()
        {
            _logger.LogInformation("Récupération de tous les CurvePoint.");
            var curvePoints = await _service.GetAllAsync();
            return Ok(curvePoints);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<CurvePointModel>> GetCurvePoint(int id)
        {
            _logger.LogInformation("Récupération du CurvePoint avec ID : {Id}", id);
            var curvePoint = await _service.GetByIdAsync(id);
            if (curvePoint == null)
            {
                _logger.LogWarning("CurvePoint avec ID : {Id} non trouvé.", id);
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
                _logger.LogInformation("Ajout d'un nouveau CurvePoint.");
                var newCurvePoint = await _service.AddAsync(curvePointDTO);
                return CreatedAtAction(nameof(GetCurvePoint), new { id = newCurvePoint.Id }, newCurvePoint);
            }
            _logger.LogWarning("Échec de la validation du modèle lors de l'ajout d'un CurvePoint.");
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCurvePoint(int id, CurvePointModel curvePointDTO)
        {
            if (id != curvePointDTO.Id)
            {
                _logger.LogWarning("Échec de la mise à jour : les ID ne correspondent pas.");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Mise à jour du CurvePoint avec ID : {Id}", id);
                var updatedCurvePoint = await _service.UpdateAsync(id, curvePointDTO);
                if (updatedCurvePoint == null)
                {
                    _logger.LogWarning("CurvePoint avec ID : {Id} non trouvé.", id);
                    return NotFound();
                }
                return NoContent();
            }
            _logger.LogWarning("Échec de la validation du modèle lors de la mise à jour d'un CurvePoint.");
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            _logger.LogInformation("Suppression du CurvePoint avec ID : {Id}", id);
            var curvePoint = await _service.GetByIdAsync(id);
            if (curvePoint == null)
            {
                _logger.LogWarning("CurvePoint avec ID : {Id} non trouvé pour suppression.", id);
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Microsoft.Extensions.Logging;
using P7CreateRestApi.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _service;
        private readonly ILogger<BidListController> _logger;

        public BidListController(IBidListService service, ILogger<BidListController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<BidListDto>>> GetAllBidLists()
        {
            _logger.LogInformation("R�cup�ration de tous les BidLists.");
            var bidLists = await _service.GetAllAsync();

            return Ok(bidLists);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BidListDto>> GetBidList(int id)
        {
            _logger.LogInformation("R�cup�ration du BidList avec l'id {id}", id);
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
                _logger.LogWarning("BidList avec l'id {id} non trouv�.", id);
                return NotFound();
            }

            return Ok(bidList);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BidListDto>> AddBidList([FromBody] BidListDto bidListDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Ajout d'un nouveau BidList.");

                var newBidList = await _service.AddAsync(bidListDto);

                return CreatedAtAction(nameof(GetBidList), new { id = newBidList.BidListId }, newBidList);
            }

            _logger.LogWarning("Mod�le d'ajout de BidList invalide.");
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBidList(int id, [FromBody] BidListDto bidListDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Mise � jour du BidList avec l'id {id}", id);

                var updatedBidList = await _service.UpdateAsync(id, bidListDto);
                if (updatedBidList == null)
                {
                    _logger.LogWarning("BidList avec l'id {id} non trouv� pour mise � jour.", id);
                    return NotFound();
                }

                return NoContent();
            }

            _logger.LogWarning("Mod�le de mise � jour du BidList invalide.");
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBidList(int id)
        {
            _logger.LogInformation("Suppression du BidList avec l'id {id}", id);
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
                _logger.LogWarning("BidList avec l'id {id} non trouv� pour suppression.", id);
                return NotFound();
            }

            await _service.DeleteAsync(id);
            _logger.LogInformation("BidList avec l'id {id} supprim� avec succ�s.", id);
            return NoContent();
        }
    }
}

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
        public async Task<ActionResult<IEnumerable<BidListModel>>> GetAllBidLists()
        {
            _logger.LogInformation("R�cup�ration de tous les BidLists");
            var bidLists = await _service.GetAllAsync();
            return Ok(bidLists);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BidListModel>> GetBidList(int id)
        {
            _logger.LogInformation("R�cup�ration du BidList avec l'id {id}", id);
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
                _logger.LogWarning("BidList avec l'id {id} non trouv�", id);
                return NotFound();
            }
            return Ok(bidList);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BidListModel>> AddBidList(BidListModel bidListDTO)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Ajout d'un nouveau BidList");
                var newBidList = await _service.AddAsync(bidListDTO);
                return CreatedAtAction(nameof(GetBidList), new { id = newBidList.BidListId }, newBidList);
            }
            _logger.LogWarning("Mod�le d'ajout de BidList invalide");
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBidList(int id, BidListModel bidListDTO)
        {
            if (id != bidListDTO.BidListId)
            {
                _logger.LogWarning("�chec de la mise � jour, l'id {id} ne correspond pas au BidList", id);
                return BadRequest();
            }

            var updatedBidList = await _service.UpdateAsync(id, bidListDTO);
            if (updatedBidList == null)
            {
                _logger.LogWarning("BidList avec l'id {id} non trouv� pour mise � jour", id);
                return NotFound();
            }

            _logger.LogInformation("Mise � jour r�ussie pour le BidList avec l'id {id}", id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBidList(int id)
        {
            _logger.LogInformation("Suppression du BidList avec l'id {id}", id);
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
                _logger.LogWarning("BidList avec l'id {id} non trouv� pour suppression", id);
                return NotFound();
            }

            await _service.DeleteAsync(id);
            _logger.LogInformation("BidList avec l'id {id} supprim� avec succ�s", id);
            return NoContent();
        }
    }
}

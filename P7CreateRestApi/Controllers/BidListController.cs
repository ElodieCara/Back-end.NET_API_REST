using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _service;

        public BidListController(IBidListService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BidListDTO>>> GetAllBidLists()
        {
            var bidLists = await _service.GetAllAsync();
            return Ok(bidLists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BidListDTO>> GetBidList(int id)
        {
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
                return NotFound();
            }
            return Ok(bidList);
        }

        [HttpPost]
        public async Task<ActionResult<BidListDTO>> AddBidList(BidListDTO bidListDTO)
        {
            if (ModelState.IsValid)
            {
                var newBidList = await _service.AddAsync(bidListDTO);
                return CreatedAtAction(nameof(GetBidList), new { id = newBidList.BidListId }, newBidList);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBidList(int id, BidListDTO bidListDTO)
        {
            if (id != bidListDTO.BidListId)
            {
                return BadRequest();
            }

            var updatedBidList = await _service.UpdateAsync(id, bidListDTO);
            if (updatedBidList == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBidList(int id)
        {
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

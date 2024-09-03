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
    public class BidListController : ControllerBase
    {
        private readonly IBidListService _service;

        public BidListController(IBidListService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<BidListModel>>> GetAllBidLists()
        {
            var bidLists = await _service.GetAllAsync();
            return Ok(bidLists);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<BidListModel>> GetBidList(int id)
        {
            var bidList = await _service.GetByIdAsync(id);
            if (bidList == null)
            {
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
                var newBidList = await _service.AddAsync(bidListDTO);
                return CreatedAtAction(nameof(GetBidList), new { id = newBidList.BidListId }, newBidList);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBidList(int id, BidListModel bidListDTO)
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
        [Authorize(Roles = "Admin")]
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

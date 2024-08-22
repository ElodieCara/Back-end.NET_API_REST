using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;


namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {

        private readonly IBidListService _bidListService;

        public BidListController(IBidListService bidListService)
        {
            _bidListService = bidListService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBidById(int id)
        {
            var bidList = await _bidListService.GetBidByIdAsync(id);
            if (bidList == null)
            {
                return NotFound();
            }
            return Ok(bidList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBid([FromBody] BidList bidList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bidListService.ValidateBidAsync(bidList);
            await _bidListService.AddBidAsync(bidList);

            return CreatedAtAction(nameof(GetBidById), new { id = bidList.BidListId }, bidList);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBid(int id, [FromBody] BidList bidList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bidListService.UpdateBidAsync(id, bidList);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(bidList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            try
            {
                await _bidListService.DeleteBidAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
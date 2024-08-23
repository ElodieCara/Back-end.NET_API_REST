using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _service;

        public TradeController(ITradeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeDTO>>> GetAllTrades()
        {
            var trades = await _service.GetAllAsync();
            return Ok(trades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TradeDTO>> GetTrade(int id)
        {
            var trade = await _service.GetByIdAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            return Ok(trade);
        }

        [HttpPost]
        public async Task<ActionResult<TradeDTO>> AddTrade(TradeDTO tradeDTO)
        {
            if (ModelState.IsValid)
            {
                var newTrade = await _service.AddAsync(tradeDTO);
                return CreatedAtAction(nameof(GetTrade), new { id = newTrade.TradeId }, newTrade);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrade(int id, TradeDTO tradeDTO)
        {
            if (id != tradeDTO.TradeId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedTrade = await _service.UpdateAsync(id, tradeDTO);
                if (updatedTrade == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            var trade = await _service.GetByIdAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

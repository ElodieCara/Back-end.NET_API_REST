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
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _service;

        public TradeController(ITradeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<TradeModel>>> GetAllTrades()
        {
            var trades = await _service.GetAllAsync();
            return Ok(trades);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<TradeModel>> GetTrade(int id)
        {
            var trade = await _service.GetByIdAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            return Ok(trade);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TradeModel>> AddTrade(TradeModel tradeDTO)
        {
            if (ModelState.IsValid)
            {
                var newTrade = await _service.AddAsync(tradeDTO);
                return CreatedAtAction(nameof(GetTrade), new { id = newTrade.TradeId }, newTrade);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTrade(int id, TradeModel tradeDTO)
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
        [Authorize(Roles = "Admin")]
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

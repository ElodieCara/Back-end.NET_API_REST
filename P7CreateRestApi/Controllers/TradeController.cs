using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using P7CreateRestApi.Models.DTOs;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _service;
        private readonly ILogger<TradeController> _logger;

        public TradeController(ITradeService service, ILogger<TradeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<TradeDto>>> GetAllTrades()
        {
            _logger.LogInformation("Fetching all trades.");
            var trades = await _service.GetAllAsync();
            return Ok(new { Message = "All trades fetched successfully.", Data = trades });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<TradeDto>> GetTrade(int id)
        {
            _logger.LogInformation("Fetching trade with ID: {TradeId}", id);
            var trade = await _service.GetByIdAsync(id);
            if (trade == null)
            {
                _logger.LogWarning("Trade with ID: {TradeId} not found.", id);
                return NotFound(new { Message = $"Trade with ID {id} not found." });
            }

            return Ok(new { Message = $"Trade with ID {id} fetched successfully.", Data = trade });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<TradeDto>> AddTrade([FromBody] TradeDto tradeDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Adding new trade.");
                var newTrade = await _service.AddAsync(tradeDto);
                return CreatedAtAction(nameof(GetTrade), new { id = newTrade.TradeId }, new { Message = "Trade created successfully.", Data = newTrade });
            }

            _logger.LogError("Invalid model state while adding a trade.");
            return BadRequest(new { Message = "Invalid model state.", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTrade(int id, [FromBody] TradeDto tradeDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Updating trade with ID: {TradeId}", id);
                var updatedTrade = await _service.UpdateAsync(id, tradeDto);
                if (updatedTrade == null)
                {
                    _logger.LogWarning("Trade with ID: {TradeId} not found.", id);
                    return NotFound(new { Message = $"Trade with ID {id} not found for update." });
                }

                return Ok(new { Message = $"Trade with ID {id} updated successfully.", Data = updatedTrade });
            }

            _logger.LogError("Invalid model state while updating trade with ID: {TradeId}", id);
            return BadRequest(new { Message = "Invalid model state.", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTrade(int id)
        {
            _logger.LogInformation("Deleting trade with ID: {TradeId}", id);
            var trade = await _service.GetByIdAsync(id);
            if (trade == null)
            {
                _logger.LogWarning("Trade with ID: {TradeId} not found.", id);
                return NotFound(new { Message = $"Trade with ID {id} not found for deletion." });
            }

            await _service.DeleteAsync(id);
            _logger.LogInformation("Trade with ID {TradeId} deleted successfully.", id);
            return Ok(new { Message = $"Trade with ID {id} deleted successfully." });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using Dot.Net.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _service;

        public RuleNameController(IRuleNameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RuleNameDTO>>> GetAllRuleNames()
        {
            var ruleNames = await _service.GetAllAsync();
            return Ok(ruleNames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RuleNameDTO>> GetRuleName(int id)
        {
            var ruleName = await _service.GetByIdAsync(id);
            if (ruleName == null)
            {
                return NotFound();
            }
            return Ok(ruleName);
        }

        [HttpPost]
        public async Task<ActionResult<RuleNameDTO>> AddRuleName(RuleNameDTO ruleNameDTO)
        {
            if (ModelState.IsValid)
            {
                var newRuleName = await _service.AddAsync(ruleNameDTO);
                return CreatedAtAction(nameof(GetRuleName), new { id = newRuleName.Id }, newRuleName);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRuleName(int id, RuleNameDTO ruleNameDTO)
        {
            if (id != ruleNameDTO.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var updatedRuleName = await _service.UpdateAsync(id, ruleNameDTO);
                if (updatedRuleName == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuleName(int id)
        {
            var ruleName = await _service.GetByIdAsync(id);
            if (ruleName == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

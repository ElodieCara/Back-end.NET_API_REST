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
    public class RuleNameController : ControllerBase
    {
        private readonly IRuleNameService _service;

        public RuleNameController(IRuleNameService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<RuleNameModel>>> GetAllRuleNames()
        {
            var ruleNames = await _service.GetAllAsync();
            return Ok(ruleNames);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<RuleNameModel>> GetRuleName(int id)
        {
            var ruleName = await _service.GetByIdAsync(id);
            if (ruleName == null)
            {
                return NotFound();
            }
            return Ok(ruleName);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RuleNameModel>> AddRuleName(RuleNameModel ruleNameDTO)
        {
            if (ModelState.IsValid)
            {
                var newRuleName = await _service.AddAsync(ruleNameDTO);
                return CreatedAtAction(nameof(GetRuleName), new { id = newRuleName.Id }, newRuleName);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRuleName(int id, RuleNameModel ruleNameDTO)
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
        [Authorize(Roles = "Admin")]
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

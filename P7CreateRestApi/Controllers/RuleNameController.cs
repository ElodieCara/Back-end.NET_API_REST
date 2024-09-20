using Microsoft.AspNetCore.Mvc;
using Dot.Net.WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using P7CreateRestApi.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class RuleNameController : ControllerBase
{
    private readonly IRuleNameService _service;
    private readonly ILogger<RuleNameController> _logger;

    public RuleNameController(IRuleNameService service, ILogger<RuleNameController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<IEnumerable<RuleNameDto>>> GetAllRuleNames()
    {
        _logger.LogInformation("Fetching all rule names.");
        var ruleNames = await _service.GetAllAsync();
        return Ok(ruleNames);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<RuleNameDto>> GetRuleName(int id)
    {
        _logger.LogInformation("Fetching rule name with ID: {RuleId}", id);
        var ruleName = await _service.GetByIdAsync(id);
        if (ruleName == null)
        {
            _logger.LogWarning("Rule name with ID: {RuleId} not found.", id);
            return NotFound();
        }

        return Ok(ruleName);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<RuleNameDto>> AddRuleName([FromBody] RuleNameDto ruleNameDto)
    {
        if (ModelState.IsValid)
        {
            _logger.LogInformation("Adding new rule name.");
            var newRuleName = await _service.AddAsync(ruleNameDto);
            return CreatedAtAction(nameof(GetRuleName), new { id = newRuleName.Id }, newRuleName);
        }

        _logger.LogError("Invalid model state while adding a rule name.");
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateRuleName(int id, [FromBody] RuleNameDto ruleNameDto)
    {
        if (ModelState.IsValid)
        {
            _logger.LogInformation("Updating rule name with ID: {RuleId}", id);
            var updatedRuleName = await _service.UpdateAsync(id, ruleNameDto);
            if (updatedRuleName == null)
            {
                _logger.LogWarning("Rule name with ID: {RuleId} not found for update.", id);
                return NotFound();
            }

            return NoContent();
        }

        _logger.LogError("Invalid model state while updating rule name with ID: {RuleId}", id);
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteRuleName(int id)
    {
        _logger.LogInformation("Deleting rule name with ID: {RuleId}", id);
        var ruleName = await _service.GetByIdAsync(id);
        if (ruleName == null)
        {
            _logger.LogWarning("Rule name with ID: {RuleId} not found for deletion.", id);
            return NotFound();
        }
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

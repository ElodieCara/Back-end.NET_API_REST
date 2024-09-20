using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;
using Dot.Net.WebApi.Models;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;

namespace Dot.Net.WebApi.Services
{
    public class RuleNameService : IRuleNameService
    {
        private readonly IRuleNameRepository _repository;

        public RuleNameService(IRuleNameRepository repository)
        {
            _repository = repository;
        }

        // Le service retourne des DTOs pour être compatible avec le contrôleur
        public async Task<IEnumerable<RuleNameDto>> GetAllAsync()
        {
            var rules = await _repository.GetAllAsync();
            return rules.Select(r => new RuleNameDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Json = r.Json,
                Template = r.Template,
                SqlStr = r.SqlStr,
                SqlPart = r.SqlPart
            });
        }

        public async Task<RuleNameDto> GetByIdAsync(int id)
        {
            var rule = await _repository.GetByIdAsync(id);
            if (rule == null)
            {
                return null!;
            }
            return new RuleNameDto
            {
                Id = rule.Id,
                Name = rule.Name,
                Description = rule.Description,
                Json = rule.Json,
                Template = rule.Template,
                SqlStr = rule.SqlStr,
                SqlPart = rule.SqlPart
            };
        }

        public async Task<RuleNameDto> AddAsync(RuleNameDto dto)
        {
            var ruleName = new RuleName
            {
                Name = dto.Name,
                Description = dto.Description,
                Json = dto.Json,
                Template = dto.Template,
                SqlStr = dto.SqlStr,
                SqlPart = dto.SqlPart
            };
            await _repository.AddAsync(ruleName);
            dto.Id = ruleName.Id;
            return dto;
        }

        public async Task<RuleNameDto> UpdateAsync(int id, RuleNameDto dto)
        {
            var rule = await _repository.GetByIdAsync(id);
            if (rule == null)
            {
                return null!;
            }

            rule.Name = dto.Name;
            rule.Description = dto.Description;
            rule.Json = dto.Json;
            rule.Template = dto.Template;
            rule.SqlStr = dto.SqlStr;
            rule.SqlPart = dto.SqlPart;

            await _repository.UpdateAsync(rule);

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

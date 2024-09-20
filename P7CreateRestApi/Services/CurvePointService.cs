using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P7CreateRestApi.Models.DTOs;
using Dot.Net.WebApi.Repositories;
using Dot.Net.WebApi.Domain;

namespace Dot.Net.WebApi.Services
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _repository;

        public CurvePointService(ICurvePointRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CurvePointDto>> GetAllAsync()
        {
            var curvePoints = await _repository.GetAllAsync();
            return curvePoints.Select(cp => new CurvePointDto
            {
                Id = cp.Id,
                CurveId = cp.CurveId,
                AsOfDate = cp.AsOfDate,
                Term = cp.Term,
                CurvePointValue = cp.CurvePointValue
            }).ToList();
        }

        public async Task<CurvePointDto> GetByIdAsync(int id)
        {
            var curvePoint = await _repository.GetByIdAsync(id);
            if (curvePoint == null)
            {
                return null!;
            }
            return new CurvePointDto
            {
                Id = curvePoint.Id,
                CurveId = curvePoint.CurveId,
                AsOfDate = curvePoint.AsOfDate,
                Term = curvePoint.Term,
                CurvePointValue = curvePoint.CurvePointValue
            };
        }

        public async Task<CurvePointDto> AddAsync(CurvePointDto dto)
        {
            var curvePoint = new CurvePoint
            {
                CurveId = dto.CurveId,
                AsOfDate = dto.AsOfDate,
                Term = dto.Term,
                CurvePointValue = dto.CurvePointValue
            };
            await _repository.AddAsync(curvePoint);
            dto.Id = curvePoint.Id;
            return dto;
        }

        public async Task<CurvePointDto> UpdateAsync(int id, CurvePointDto dto)
        {
            var curvePoint = await _repository.GetByIdAsync(id);
            if (curvePoint == null)
            {
                return null!;
            }

            curvePoint.CurveId = dto.CurveId;
            curvePoint.AsOfDate = dto.AsOfDate;
            curvePoint.Term = dto.Term;
            curvePoint.CurvePointValue = dto.CurvePointValue;

            await _repository.UpdateAsync(curvePoint);

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

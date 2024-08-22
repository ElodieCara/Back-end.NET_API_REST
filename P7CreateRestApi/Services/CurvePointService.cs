using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories;


namespace Dot.Net.WebApi.Services
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _repository;

        public CurvePointService(ICurvePointRepository repository)
        {
            _repository = repository;
        }

        public void AddCurvePoint(CurvePoint curvePoint)
        {
            _repository.Add(curvePoint);
        }

        public CurvePoint GetCurvePointById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateCurvePoint(CurvePoint curvePoint)
        {
            _repository.Update(curvePoint);
        }

        public void DeleteCurvePoint(int id)
        {
            _repository.Delete(id);
        }
    }
}
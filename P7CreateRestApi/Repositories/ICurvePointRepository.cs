using Dot.Net.WebApi.Domain;

namespace P7CreateRestApi.Repositories
{
    public interface ICurvePointRepository
    {
        void Add(CurvePoint curvePoint);
        CurvePoint GetById(int id);
        void Update(CurvePoint curvePoint);
        void Delete(int id);
    }

}

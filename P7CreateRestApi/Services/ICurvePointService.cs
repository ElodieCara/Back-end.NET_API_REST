using Dot.Net.WebApi.Domain;


namespace Dot.Net.WebApi.Services
{
    public interface ICurvePointService
    {

        void AddCurvePoint(CurvePoint curvePoint);
        CurvePoint GetCurvePointById(int id);
        void UpdateCurvePoint(CurvePoint curvePoint);
        void DeleteCurvePoint(int id);
    }
}
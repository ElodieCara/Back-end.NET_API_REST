using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Data;
using P7CreateRestApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;


namespace Dot.Net.WebApi.Repositories
{
    public class CurvePointRepository : ICurvePointRepository
    {
        private readonly LocalDbContext _context;

        public CurvePointRepository(LocalDbContext context)
        {
            _context = context;
        }

        public void Add(CurvePoint curvePoint)
        {
            _context.CurvePoints.Add(curvePoint);
            _context.SaveChanges();
        }

        public CurvePoint GetById(int id)
        {
            return _context.CurvePoints.Find(id);
        }

        public void Update(CurvePoint curvePoint)
        {
            _context.CurvePoints.Update(curvePoint);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var curvePoint = _context.CurvePoints.Find(id);
            if (curvePoint != null)
            {
                _context.CurvePoints.Remove(curvePoint);
                _context.SaveChanges();
            }
        }
    }
}

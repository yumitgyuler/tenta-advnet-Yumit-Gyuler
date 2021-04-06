using DataAccess.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Service
{
    public class AreaService
    {
        EfAreaDal hamsterDal = new EfAreaDal();
        public List<Area> GetAll()
        {
            return hamsterDal.GetAll();
        }
        public List<Area> GetByAreaType(int typeId)
        {
            return hamsterDal.GetByAreaType(typeId);
        }
        public Area GetById(Expression<Func<Area, bool>> filter)
        {
            return hamsterDal.GetById(filter);
        }
        public void Update(Area area)
        {
            hamsterDal.Update(area);
        }
    }
}

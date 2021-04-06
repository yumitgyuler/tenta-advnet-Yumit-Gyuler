using Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace DataAccess.EntityFramework
{
    public class EfAreaDal
    {
        public List<Area> GetAll()
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                return context.Set<Area>().ToList();
            }
        }
        public List<Area> GetByAreaType(int typeId)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                return context.Areas.Include("ActivityLogs").Where(a => a.AreaTypeId == typeId).ToList();
            }
        }
        public Area GetById(Expression<Func<Area, bool>> filter)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                return context.Areas.Include("ActivityLogs").SingleOrDefault(filter);
            }
        }
        public void Update(Area area)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                var addedEntity = context.Entry(area);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

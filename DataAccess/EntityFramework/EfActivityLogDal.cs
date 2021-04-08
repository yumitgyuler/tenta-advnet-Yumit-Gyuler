using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.EntityFramework
{
    public class EfActivityLogDal
    {
        public void Add(ActivityLog activityLog)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                var addedEntity = context.Entry(activityLog);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(ActivityLog activityLog)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                var addedEntity = context.Entry(activityLog);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<ActivityLog> GetById(Expression<Func<ActivityLog, bool>> filter)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                return context.ActivityLogs.Include("Hamster").Where(filter).ToList();
            }
        }
    }
}

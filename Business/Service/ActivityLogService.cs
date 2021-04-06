using DataAccess.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Service
{
    public class ActivityLogService
    {
        EfActivityLogDal activityLogDal = new EfActivityLogDal();
        public void Add(ActivityLog activityLog)
        {
            activityLogDal.Add(activityLog);
        }
        public void Update(ActivityLog activityLog)
        {
            activityLogDal.Update(activityLog);
        }
        public List<ActivityLog> GetById(Expression<Func<ActivityLog, bool>> filter)
        {
            return activityLogDal.GetById(filter);
        }
    }
}

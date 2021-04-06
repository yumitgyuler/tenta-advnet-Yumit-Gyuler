using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class EfHamsterDal
    {
        public Hamster GetById(int id)
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                return context.Hamsters.Include("ActivityLogs").SingleOrDefault(h => h.Id == id);
            }
        }
        public List<Hamster> GetAll()
        {
            using (advYumitGyulerContext context = new advYumitGyulerContext())
            {
                return context.Hamsters.Include("ActivityLogs").ToList();
            }
        }
    }
}

using DataAccess.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service
{
    public class HamsterService
    {
        EfHamsterDal hamsterDal = new EfHamsterDal();
        public List<Hamster> GetAll()
        {
            return hamsterDal.GetAll();
        }
        public Hamster GetById(int id)
        {
            return hamsterDal.GetById(id);
        }
    }
}

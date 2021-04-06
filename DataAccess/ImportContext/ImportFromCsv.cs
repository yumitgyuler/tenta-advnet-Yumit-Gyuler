using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess.ImportContext
{
    public class ImportFromCsv
    {
        public static IEnumerable<Hamster> CSVToList()
        {
            var data = File.ReadAllLines(@"Hamsterlista30.csv");
            return data.Select(m => m.Split(";")).Select(m => new Hamster() { Id = Convert.ToInt16(m[0]), Name = m[1], Age = Convert.ToByte(m[2]), Gender = m[3], OwnerFullName = m[4] }).ToList();
        }
    }
}

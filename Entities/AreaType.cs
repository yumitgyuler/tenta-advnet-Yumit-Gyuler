using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public class AreaType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}

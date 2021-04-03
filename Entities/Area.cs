using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public class Area
    {
        public int Id { get; set; }
        public int AreaTypeId { get; set; }
        public int StatusId { get; set; }
        public int Capacity { get; set; }

        public virtual AreaType AreaType { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}

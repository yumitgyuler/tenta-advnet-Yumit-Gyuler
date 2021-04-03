using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int HamsterId { get; set; }
        public int ActivityId { get; set; }
        public int? AreaId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Area Area { get; set; }
        public virtual Hamster Hamster { get; set; }
    }
}

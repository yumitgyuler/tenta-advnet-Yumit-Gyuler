using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public class Hamster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerFullName { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}

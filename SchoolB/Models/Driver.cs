using System;
using System.Collections.Generic;

namespace SchoolB.Models
{
    public partial class Driver
    {
        public Driver()
        {
            buses = new HashSet<bus>();
        }

        public int DriverId { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<bus> buses { get; set; }
    }
}

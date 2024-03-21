using System;
using System.Collections.Generic;

namespace SchoolB.Models
{
    public partial class bus
    {
        public bus()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int BusId { get; set; }
        public int? DriverId { get; set; }
        public int? RouteId { get; set; }

        public virtual Driver? Driver { get; set; }
        public virtual Route? Route { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

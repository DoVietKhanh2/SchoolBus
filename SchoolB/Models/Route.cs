using System;
using System.Collections.Generic;

namespace SchoolB.Models
{
    public partial class Route
    {
        public Route()
        {
            Tickets = new HashSet<Ticket>();
            buses = new HashSet<bus>();
        }

        public int RouteId { get; set; }
        public string? RouteName { get; set; }
        public string? StartLocation { get; set; }
        public string? EndLocation { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<bus> buses { get; set; }
    }
}

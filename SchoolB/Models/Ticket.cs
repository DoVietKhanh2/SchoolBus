using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolB.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int? UserId { get; set; }
        public int? RouteId { get; set; }
        public int? BusId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty")]
        public int? NumberOfMonths { get; set; }
        public string? Address { get; set; }

        public virtual bus? Bus { get; set; }
        public virtual Route? Route { get; set; }
        public virtual User? User { get; set; }
    }
}

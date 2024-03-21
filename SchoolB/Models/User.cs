using System;
using System.Collections.Generic;

namespace SchoolB.Models
{
    public partial class User
    {
        public User()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

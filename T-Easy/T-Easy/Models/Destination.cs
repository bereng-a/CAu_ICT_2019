using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class Destination
    {
        public Destination()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public int TravelId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Address { get; set; }

        public virtual Travel IdNavigation { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}

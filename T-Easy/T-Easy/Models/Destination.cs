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
        public int CityId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public virtual City City { get; set; }
        public virtual Travel Travel { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace T_Easy.Models
{
    public partial class Destination
    {
        public Destination()
        {
            Event = new ObservableCollection<Event>();
        }

        public int Id { get; set; }
        public int TravelId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Address { get; set; }

        public virtual Travel IdNavigation { get; set; }
        public virtual ObservableCollection<Event> Event { get; set; }
    }
}

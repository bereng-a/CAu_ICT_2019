using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class Event
    {
        public Event()
        {
            Document = new HashSet<Document>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int DestinationId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }

        public virtual Destination Destination { get; set; }
        public virtual EventType Type { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

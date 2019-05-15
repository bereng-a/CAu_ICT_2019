using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class Travel
    {
        public Travel()
        {
            Destination = new HashSet<Destination>();
            Document = new HashSet<Document>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SharingCode { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Destination> Destination { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}

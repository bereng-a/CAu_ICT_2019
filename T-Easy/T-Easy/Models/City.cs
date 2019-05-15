using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class City
    {
        public City()
        {
            Destination = new HashSet<Destination>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Destination> Destination { get; set; }
    }
}

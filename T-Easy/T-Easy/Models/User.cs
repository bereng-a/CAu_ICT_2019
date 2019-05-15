using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class User
    {
        public User()
        {
            Document = new HashSet<Document>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int? TravelId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }

        public virtual Travel Travel { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}

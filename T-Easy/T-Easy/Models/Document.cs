using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public int TravelId { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Path { get; set; }
        public int? EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Travel Travel { get; set; }
        public virtual DocumentType Type { get; set; }
        public virtual User User { get; set; }
    }
}

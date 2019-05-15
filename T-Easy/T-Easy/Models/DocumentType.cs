using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}

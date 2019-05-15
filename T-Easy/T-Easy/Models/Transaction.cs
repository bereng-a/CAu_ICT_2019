﻿using System;
using System.Collections.Generic;

namespace T_Easy.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int Cost { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Event Event { get; set; }
        public virtual User User { get; set; }
    }
}

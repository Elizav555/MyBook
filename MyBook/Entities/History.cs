﻿namespace MyBook.Entities
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
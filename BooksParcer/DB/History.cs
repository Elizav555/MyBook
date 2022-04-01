using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public DateTime DateTime { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Book Book { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}

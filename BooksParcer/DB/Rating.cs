using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public double Points { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}

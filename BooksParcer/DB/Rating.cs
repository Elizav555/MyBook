using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public double Points { get; set; }
        public int FkRatingUserUserId { get; set; }
        public int FkRatingBookBookId { get; set; }

        public virtual Book FkRatingBookBook { get; set; } = null!;
        public virtual User FkRatingUserUser { get; set; } = null!;
    }
}

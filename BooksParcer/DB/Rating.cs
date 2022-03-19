using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksParcer
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public double Points { get; set; }
        [ForeignKey("FK_rating_user_userId")]
        public virtual User User { get; set; } = null!;
        [ForeignKey("FK_rating_book_bookId")]
        public virtual Book Book { get; set; } = null!;
    }
}

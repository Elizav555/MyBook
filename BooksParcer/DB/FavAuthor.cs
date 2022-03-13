using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class FavAuthor
    {
        public int FavAuthorId { get; set; }
        public int AuthorId { get; set; }
        public int UserId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

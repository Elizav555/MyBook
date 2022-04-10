using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class FavAuthor
    {
        public int FavAuthorId { get; set; }
        public int AuthorId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Author Author { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}

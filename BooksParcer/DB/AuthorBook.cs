using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class AuthorBook
    {
        public int AuthorBookId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}

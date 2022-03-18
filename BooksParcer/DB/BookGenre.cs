using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class BookGenre
    {
        public int BookGenreId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}

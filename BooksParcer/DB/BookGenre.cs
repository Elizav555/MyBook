using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class BookGenre
    {
        public int BookGenreId { get; set; }
        public int GenreId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}

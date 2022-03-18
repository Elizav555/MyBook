using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class FavGenre
    {
        public int FavGenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

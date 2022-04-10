using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class FavGenre
    {
        public int FavGenreId { get; set; }
        public int GenreId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Genre Genre { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}

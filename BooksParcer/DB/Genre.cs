﻿using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
            FavGenres = new HashSet<FavGenre>();
            SubscGenres = new HashSet<SubscGenre>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<FavGenre> FavGenres { get; set; }
        public virtual ICollection<SubscGenre> SubscGenres { get; set; }
    }
}

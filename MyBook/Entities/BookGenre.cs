﻿namespace MyBook.Entities
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
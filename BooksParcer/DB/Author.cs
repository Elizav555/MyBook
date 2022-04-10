﻿using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Author
    {
        public Author()
        {
            AuthorBooks = new HashSet<AuthorBook>();
            FavAuthors = new HashSet<FavAuthor>();
            ImgLinks = new HashSet<ImgLink>();
            SubscrAuthors = new HashSet<SubscrAuthor>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public string? BirthDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<ImgLink> ImgLinks { get; set; }
        public virtual ICollection<SubscrAuthor> SubscrAuthors { get; set; }
    }
}

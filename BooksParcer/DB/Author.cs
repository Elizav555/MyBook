using System;
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
            SubscrTypes = new HashSet<SubscrType>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly BirthDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<ImgLink> ImgLinks { get; set; }
        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
    }
}

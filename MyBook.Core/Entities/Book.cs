namespace MyBook.Entities
{
    public partial class Book
    {
        public Book()
        {
            AuthorBooks = new HashSet<AuthorBook>();
            BookGenres = new HashSet<BookGenre>();
            Histories = new HashSet<History>();
            ImgLinks = new HashSet<ImgLink>();
        }

        public int BookId { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string? PublishedDate { get; set; }
        public bool IsForAdult { get; set; }
        public bool IsPaid { get; set; }

        public int DescriptionId { get; set; }
        public virtual BookDesc Description { get; set; } = null!;
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<ImgLink> ImgLinks { get; set; }
    }
}

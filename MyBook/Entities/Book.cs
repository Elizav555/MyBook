namespace MyBook.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int RatingId { get; set; }
        public string Language { get; set; } = "en";
        public DateOnly PublishedDate { get; set; }
        public int DescriptionId { get; set; }
        public bool IsForAdult { get; set; }

        public virtual ICollection<BookGenre> Genres { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual BookDescription Description { get; set; }
        public virtual ICollection<AuthorBook> Authors { get; set; }
        public virtual ICollection<History> Readers { get; set; }
        public virtual ICollection<ImgLink> Images { get; set; }

    }
}

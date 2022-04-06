namespace MyBook.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly BirthDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<ImgLink> ImgLinks { get; set; }
        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
    }
}

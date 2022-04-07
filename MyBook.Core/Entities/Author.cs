namespace MyBook.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
        public String? BirthDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<SubscrAuthor> SubscrAuthors { get; set; }
        public virtual ICollection<ImgLink> ImgLinks { get; set; }
    }
}

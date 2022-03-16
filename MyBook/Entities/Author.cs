namespace MyBook.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateOnly BirthDate { get; set; }

        public virtual ICollection<AuthorBook> Books { get; set; }
        public virtual ICollection<FavAuthor> Fans { get; set; }
        public virtual ICollection<ImgLink> Images { get; set; }
        public virtual ICollection<SubscriptionType> Followers { get; set; }
    }
}

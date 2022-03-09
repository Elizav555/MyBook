namespace MyBook.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public virtual ICollection<BookGenre> Books { get; set; }
        public virtual ICollection<FavGenre> Fans { get; set; }
        public virtual ICollection<SubscriptionType> Followers { get; set; }
    }
}

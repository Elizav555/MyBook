namespace MyBook.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
            FavGenres = new HashSet<FavGenre>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<FavGenre> FavGenres { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}

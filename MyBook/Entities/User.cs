namespace MyBook.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; } = false;
        public int InfoId { get; set; }

        public virtual ICollection<UserSubscriptions>? Subscriptions { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<History> History { get; set; }
        public virtual ICollection<FavAuthor> FavAuthors { get; set; }
        public virtual ICollection<FavGenre> FavGenres { get; set; }
        public virtual ICollection<Rating> Marks { get; set; }
    }
}

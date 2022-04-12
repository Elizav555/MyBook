namespace MyBook.Entities
{
    public class SubscrGenre
    {
        public int SubscrGenreId { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; } = null!;
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscr { get; set; } = null!;
    }
}
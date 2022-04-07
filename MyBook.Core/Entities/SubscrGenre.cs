namespace MyBook.Entities
{
    public class SubscrGenre
    {
        public int SubscrGenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual Subscription Subscr { get; set; } = null!;
    }
}
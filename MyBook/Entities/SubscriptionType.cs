namespace MyBook.Entities
{
    public class SubscriptionType
    {
        public int Id { get; set; }
        public int? GenreId { get; set; }
        public int? AuthorId { get; set; }
        public bool ForPaid { get; set; } = false;

        public virtual Genre? Genre { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}

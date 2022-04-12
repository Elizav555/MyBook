namespace MyBook.Entities
{
    public class SubscrAuthor
    {
        public int SubscrAuthorId { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscr { get; set; } = null!;
    }
}
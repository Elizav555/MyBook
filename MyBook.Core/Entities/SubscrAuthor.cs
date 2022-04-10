namespace MyBook.Entities
{
    public class SubscrAuthor
    {
        public int SubscrAuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Subscription Subscr { get; set; } = null!;
    }
}
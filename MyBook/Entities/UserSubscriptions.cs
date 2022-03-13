namespace MyBook.Entities
{
    public class UserSubscriptions
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}

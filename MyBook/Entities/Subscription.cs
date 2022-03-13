namespace MyBook.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int TypeId { get; set; }

        public virtual SubscriptionType Type { get; set; }
        public virtual UserSubscriptions User { get; set; }
    }
}

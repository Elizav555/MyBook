namespace MyBook.Entities
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
        [ForeignKey("FK_subscr_user_subscr_user_subscr_id")]
        public virtual UserSubscr UserSubscr { get; set; } = null!;
    }
}
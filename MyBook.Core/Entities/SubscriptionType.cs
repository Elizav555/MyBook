namespace MyBook.Entities
{
    public partial class SubscrType
    {
        public int SubscrTypeId { get; set; }
        public virtual Subscription Subscription { get; set; } = null!;
        public virtual Type Type { get; set; } = null!;
    }
}
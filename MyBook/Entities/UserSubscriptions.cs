namespace MyBook.Entities
{
    public partial class UserSubscr
    {
        public int UserSubscrId { get; set; }

        public virtual Subscription Subscription { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

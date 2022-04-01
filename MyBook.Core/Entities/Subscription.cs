using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Entities
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        [ForeignKey("FK_subscr_type_typeId")]
        public virtual SubscrType Type { get; set; } = null!;
        [ForeignKey("FK_subscr_user_subscr_user_subscr_id")]
        public virtual UserSubscr UserSubscr { get; set; } = null!;
    }
}

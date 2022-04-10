using System.ComponentModel.DataAnnotations.Schema;

namespace MyBook.Entities
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }

        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
        [ForeignKey("FK_subscr_user_subscr_user_subscr_id")]
        public virtual UserSubscr UserSubscr { get; set; } = null!;

        public virtual ICollection<SubscrAuthor>? SubscrAuthors { get; set; }
        public virtual ICollection<SubscrGenre>? SubscrGenres { get; set; }
    }
}
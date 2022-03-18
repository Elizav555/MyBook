using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class UserSubscr
    {
        public int UserSubscrId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

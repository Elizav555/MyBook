using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class UserSubscr
    {
        public int UserSubscrId { get; set; }
        public string UserId { get; set; } = null!;
        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}

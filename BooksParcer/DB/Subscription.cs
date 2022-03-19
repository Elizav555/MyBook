using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int TypeId { get; set; }
        public virtual SubscrType Type { get; set; } = null!;
        public virtual UserSubscr UserSubscr { get; set; } = null!;
    }
}

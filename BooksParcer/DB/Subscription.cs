using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Subscription
    {
        public Subscription()
        {
            SubscrTypes = new HashSet<SubscrType>();
        }

        public int SubscrId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int FkSubscrUserSubscrUserSubscrId { get; set; }

        public virtual UserSubscr FkSubscrUserSubscrUserSubscr { get; set; } = null!;
        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Subscription
    {
        public int SubscrId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int FkSubscrTypeTypeId { get; set; }
        public int FkSubscrUserSubscrUserSubscrId { get; set; }

        public virtual SubscrType FkSubscrTypeType { get; set; } = null!;
        public virtual UserSubscr FkSubscrUserSubscrUserSubscr { get; set; } = null!;
    }
}

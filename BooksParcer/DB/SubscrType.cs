using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class SubscrType
    {
        public int SubscrTypeId { get; set; }
        public bool ForPaid { get; set; }
        public virtual Author? Author { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Subscription Subscription { get; set; } = null!;
    }
}

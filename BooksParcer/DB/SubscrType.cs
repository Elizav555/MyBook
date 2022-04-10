using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class SubscrType
    {
        public int SubscrTypeId { get; set; }
        public int SubscriptionId { get; set; }
        public int TypeId { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Subscription Subscription { get; set; } = null!;
        public virtual Type Type { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class SubscrAuthor
    {
        public int SubscrAuthorId { get; set; }
        public int AuthorId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Subscription Subscription { get; set; } = null!;
    }
}

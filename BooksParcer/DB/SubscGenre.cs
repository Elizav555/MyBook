using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class SubscGenre
    {
        public int SubscrGenreId { get; set; }
        public int GenreId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Genre Genre { get; set; } = null!;
        public virtual Subscription Subscription { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Subscription
    {
        public Subscription()
        {
            SubscGenres = new HashSet<SubscGenre>();
            SubscrAuthors = new HashSet<SubscrAuthor>();
        }

        public int SubscrId { get; set; }
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
        public int FkSubscrUserSubscrUserSubscrId { get; set; }

        public virtual UserSubscr FkSubscrUserSubscrUserSubscr { get; set; } = null!;
        public virtual ICollection<SubscGenre> SubscGenres { get; set; }
        public virtual ICollection<SubscrAuthor> SubscrAuthors { get; set; }
        public virtual Type Type { get; set; }
    }
}

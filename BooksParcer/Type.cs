using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Type
    {
        public Type()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}

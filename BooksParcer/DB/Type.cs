using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class Type
    {
        public Type()
        {
            SubscrTypes = new HashSet<SubscrType>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }

        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
    }
}

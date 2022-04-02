using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Entities
{
    public class Type
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }


        public virtual ICollection<SubscrType> SubscrTypes { get; set; }
    }
}

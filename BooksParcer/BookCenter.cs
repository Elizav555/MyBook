using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class BookCenter
    {
        public int BookCenterId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

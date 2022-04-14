using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class BookDesc
    {
        public BookDesc()
        {
            DownloadLinks = new HashSet<DownloadLink>();
        }

        public int BookDescId { get; set; }
        public string? Description { get; set; }
        public int PagesCount { get; set; }
        public string? Price { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual ICollection<DownloadLink> DownloadLinks { get; set; }
    }
}

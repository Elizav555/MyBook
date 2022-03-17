using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class DownloadLink
    {
        public int DownloadLinkId { get; set; }
        public int BookDescId { get; set; }
        public string Format { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual BookDesc BookDesc { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksParcer
{
    public class BookJson
    {
        public string Name { get; set; } = "";
        // public int? Rating { get; set; }
        public string Language { get; set; } = "en";
        public DateOnly? PublishedDate { get; set; }
        public bool IsForAdult { get; set; }
        public bool IsPaid { get; set; }
        public string? Description { get; set; }
        public int PagesCount { get; set; }
        public string Price { get; set; }
        public ICollection<Genre>? Genres { get; set; }
        public ICollection<Author>? Authors { get; set; }
        public ICollection<ImgLink> Images { get; set; }
        public ICollection<DownloadLink> DownloadLinks { get; set; }
    }

    //public class DownloadLinkJson
    //{
    //    public string Format { get; set; }
    //    public string Url { get; set; }
    //}

    //public class ImgLinkJson
    //{
    //    public string? Resolution { get; set; }
    //    public string Url { get; set; }
    //}

    //public class AuthorBookJson
    //{
    //    public string Name { get; set; } = "";
    //}

    //public class BookGenreJson
    //{
    //    public string Name { get; set; } = "";
    //}
}

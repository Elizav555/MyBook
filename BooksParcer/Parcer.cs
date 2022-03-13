using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BooksParcer
{
    public static class Parcer
    {
        public static List<BookJson> ParceJSONBooks()
        {

            var result = new List<BookJson>();

            foreach (var path in Directory.GetFiles(@"C:\IT\MyBook\BooksParcer\files"))
            {
                var root = new Root();
                using (StreamReader reader = new StreamReader(path))
                {
                    var json = reader.ReadToEnd();
                    root = JsonSerializer.Deserialize<Root>(json);
                }
                foreach (var item in root.items)
                {
                    var imgLinkSm = new ImgLinkJson { Resolution = "smallThumbnail", Url = item.volumeInfo.imageLinks.smallThumbnail };
                    var imgLink = new ImgLinkJson { Resolution = "thumbnail", Url = item.volumeInfo.imageLinks.thumbnail };
                    var epub = new DownloadLinkJson { Format = "epub", Url = item.accessInfo.epub.acsTokenLink };
                    var pdf = new DownloadLinkJson { Format = "pdf", Url = item.accessInfo.pdf.acsTokenLink };
                    var book = new BookJson
                    {
                        Name = item.volumeInfo.title,
                        Rating = item.volumeInfo.averageRating,
                        Language = item.volumeInfo.language,
                        PublishedDate = item.volumeInfo.publishedDate != null ? DateOnly.Parse(item.volumeInfo.publishedDate) : null,
                        IsForAdult = item.volumeInfo.maturityRating == "MATURE",
                        IsPaid = !item.volumeInfo.allowAnonLogging,
                        Description = item.volumeInfo.description,
                        Price = item.saleInfo.listPrice?.amount + " " + item.saleInfo.listPrice?.currencyCode,
                        PagesCount = item.volumeInfo.pageCount,
                        Genres = item.volumeInfo.categories?.Select(catName => new BookGenreJson { Name = catName }).ToList(),
                        Authors = item.volumeInfo.authors?.Select(authName => new AuthorBookJson { Name = authName }).ToList(),
                        Images = new List<ImgLinkJson> { imgLink, imgLinkSm },
                        DownloadLinks = new List<DownloadLinkJson> { epub, pdf }
                    };
                    result.Add(book);
                }
            }
            return result;
        }
    }
}

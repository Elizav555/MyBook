using System.Linq;
using BooksParcer;
using System.Text.Json;

#region BooksParcer
var booksJSON = Parcer.ParceJSONBooks();
var rnd = new Random();

foreach (var bookJSON in booksJSON)
{
    using (var db = new MyBookContext())
    {
        var rating = new Rating { Points = rnd.NextDouble() * rnd.Next(5), FkRatingUserUser = db.AspNetUsers.ToList().First() };
        var authorBooks = new List<AuthorBook>();
        var bookGenres = new List<BookGenre>();
        var bookImages = new List<ImgLink>();
        bookImages = bookJSON.Images.ToList();
        var desc = new BookDesc
        {
            Description = bookJSON.Description,
            PagesCount = bookJSON.PagesCount,
            Price = bookJSON.Price,
            DownloadLinks = bookJSON.DownloadLinks
        };
        var book = new Book
        {
            Name = bookJSON.Name,
            Language = bookJSON.Language != null ? bookJSON.Language : "en",
            PublishedDate = bookJSON.PublishedDate.ToString(),
            IsForAdult = bookJSON.IsForAdult,
            IsPaid = bookJSON.IsPaid,
            ImgLinks = bookImages,
            BookDesc = desc,
            Ratings = new List<Rating>() { rating }
        };
        if (bookJSON.Authors != null)
        {
            foreach (var author in bookJSON.Authors)
            {
                var dbAuthor = db.Authors.FirstOrDefault(a => a.Name == author.Name);
                if (dbAuthor == null)
                {
                    db.Authors.Add(author);
                    authorBooks.Add(new AuthorBook { Author = author, Book = book });
                }
                else
                {
                    authorBooks.Add(new AuthorBook { Author = dbAuthor, Book = book });
                }
            }
            book.AuthorBooks = authorBooks;
        }

        if (bookJSON.Genres != null)
        {
            foreach (var genre in bookJSON.Genres)
            {
                var dbGenre = db.Genres.FirstOrDefault(a => a.Name == genre.Name);
                if (dbGenre == null)
                {
                    db.Genres.Add(genre);
                    bookGenres.Add(new BookGenre { Genre = genre, Book = book });
                }
                else
                {
                    bookGenres.Add(new BookGenre { Genre = dbGenre, Book = book });
                }
            }
            db.BookGenres.AddRange(bookGenres);
        }
        db.SaveChanges();
    }
}
#endregion

#region AddSubscr
using (var db = new MyBookContext())
{
    var type = new BooksParcer.Type
    {
        TypeName = "Премиум",
        Price = 899,
        Description = "Доступ ко всем книгам без ограничений",
    };
    var type1 = new BooksParcer.Type
    {
        TypeName = "Подписка на автора",
        Price = 399,
        Description = "Выберите автора и получите доступ ко всем его произведениям",
    };
    var type2 = new BooksParcer.Type
    {
        TypeName = "Подписка на жанр",
        Price = 399,
        Description = "Выберите жанр и получите доступ ко всем произведениям, относящимся к нему",
    };
    db.Types.AddRange(type, type1, type2);
    db.SaveChanges();
}
#endregion
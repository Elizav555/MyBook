using BooksParcer;
using System.Text.Json;

var booksJSON = Parcer.ParceJSONBooks();
var rnd = new Random();
using (var db = new MyBookContext())
{
    var userInfo = new UserInfo
    {
        FirstName = "Elizaveta",
        LastName = "Garkina",
        BirthDate = DateOnly.Parse("2002-09-01")
    };
    var user = new User
    {
        IsAdmin = false,
        Info = userInfo,
        Login = "LOGIN",
        Password = "PASSWORD",
        Salt = "SALT"
    };
    userInfo.User = user;
    db.AddRange(userInfo, user);
    db.SaveChanges();
}
foreach (var bookJSON in booksJSON)
{
    using (var db = new MyBookContext())
    {
        var rating = new Rating { Points = rnd.NextDouble() * rnd.Next(5), UserId = 1 };
        var authorBooks = new List<AuthorBook>();
        var bookGenres = new List<BookGenre>();
        var book = new Book
        {
            Name = bookJSON.Name,
            Language = bookJSON.Language != null ? bookJSON.Language : "en",
            PublishedDate = bookJSON.PublishedDate,
            IsForAdult = bookJSON.IsForAdult,
            IsPaid = bookJSON.IsPaid,
            ImgLinks = bookJSON.Images,
        };
        rating.Book = book;
        var desc = new BookDesc
        {
            Description = bookJSON.Description,
            PagesCount = bookJSON.PagesCount,
            DownloadLinks = bookJSON.DownloadLinks,
            Book = book,
            Price = bookJSON.Price,
        };
        book.Rating = rating;
        book.Description = desc;
        if (bookJSON.Authors != null)
        {
            foreach (var author in bookJSON.Authors)
            {
                authorBooks.Add(new AuthorBook { Author = author, Book = book });
            }
            book.AuthorBooks = authorBooks;
            db.AddRange(bookJSON.Authors);
            db.AddRange(authorBooks);
        }
        if (bookJSON.Genres != null)
        {
            foreach (var genre in bookJSON.Genres)
            {
                bookGenres.Add(new BookGenre { Genre = genre, Book = book });
            }
            book.BookGenres = bookGenres;
            db.AddRange(bookJSON.Genres);
            db.AddRange(bookGenres);
        }

        db.AddRange(desc, book);
        db.SaveChanges();
    }
}
using System.Linq;
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
    db.UserInfos.Add(userInfo);
    db.Users.Add(user);
    db.SaveChanges();
}
foreach (var bookJSON in booksJSON)
{
    using (var db = new MyBookContext())
    {
        var rating = new Rating { Points = rnd.NextDouble() * rnd.Next(5), User = db.Users.ToList().First(user => user.UserId == 1) };
        var authorBooks = new List<AuthorBook>();
        var bookGenres = new List<BookGenre>();
        var bookImages = new List<ImgLink>();
        bookImages = bookJSON.Images.ToList();
        var desc = new BookDesc
        {
            Description = bookJSON.Description,
            PagesCount = bookJSON.PagesCount,
            Price = bookJSON.Price,
            DownloadLinks =  bookJSON.DownloadLinks
        };
        
        var book = new Book
        {
            Name = bookJSON.Name,
            Language = bookJSON.Language != null ? bookJSON.Language : "en",
            PublishedDate = bookJSON.PublishedDate,
            IsForAdult = bookJSON.IsForAdult,
            IsPaid = bookJSON.IsPaid,
            ImgLinks = bookImages,
            Description = desc,
            Ratings = new List<Rating>(){rating}
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
                    bookGenres.Add(new BookGenre{ Genre = genre, Book = book });
                }
                else
                {
                    bookGenres.Add(new BookGenre{ Genre = dbGenre, Book = book });
                }
            }
            db.BookGenres.AddRange(bookGenres);
        }
        db.SaveChanges();
    }
}
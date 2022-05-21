﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBook.Entities;
using MyBook.Parser;
using Type = MyBook.Entities.Type;


#region BooksParcer

var booksJSON = Parcer.ParceJSONBooks();
var rnd = new Random();

foreach (var bookJSON in booksJSON)
{
    using (var db = new MyBookContext())
    {
        var rating = new Rating
        {
            Points = rnd.Next(5),
            ReviewText = "Супер пупер топ!",
            User = db.Users.First()
        };
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
            Description = desc,
            Ratings = new List<Rating>() {rating}
        };
        rating.Book = book;
        db.Ratings.Add(rating);
        if (bookJSON.Authors != null)
        {
            foreach (var author in bookJSON.Authors)
            {
                var dbAuthor = db.Authors.FirstOrDefault(a => a.Name == author.Name);
                if (dbAuthor == null)
                {
                    db.Authors.Add(author);
                    authorBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }
                else
                {
                    authorBooks.Add(new AuthorBook {Author = dbAuthor, Book = book});
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
                    bookGenres.Add(new BookGenre {Genre = genre, Book = book});
                }
                else
                {
                    bookGenres.Add(new BookGenre {Genre = dbGenre, Book = book});
                }
            }

            db.BookGenres.AddRange(bookGenres);
        }

        db.SaveChanges();
    }
}

#endregion

#region AddBooks

using (var db = new MyBookContext())
{
    var rating = new Rating
    {
        Points = rnd.Next(5),
        ReviewText = "Пойдет",
        User = db.Users.First()
    };
    var authorBooks = new List<AuthorBook>();
    var bookGenres = new List<BookGenre>();
    var bookImages = new List<ImgLink>();

    var smallImage =
        @"https://www.imgonline.com.ua/result_img/imgonline-com-ua-Resize-SAx1mbodDnJ3i8AS.jpg";
    var bigImage =
        @"https://img3.labirint.ru/rc/4832e46d336b11b428ebc1ae9f6b2140/363x561q80/books64/638117/cover.jpg?1613035773";
    var imgLinkSm = new ImgLink { Resolution = "smallThumbnail", Url = smallImage != null && bigImage != null ? smallImage : "" };
    var imgLink = new ImgLink { Resolution = "thumbnail",  Url = smallImage != null && bigImage != null ? bigImage : "" };
   
    var epub = new DownloadLink { Format = "epub", Url = @"https://drive.google.com/uc?export=download&id=1Bsr_A-6yrTsdYYYFAnuvurCmhYTRfEH6" };
    var pdf = new DownloadLink { Format = "pdf", Url = @"https://drive.google.com/uc?export=download&id=1tMtHBHvnJof0gJd_H3UCBrLseIDWtntB" };
   
    bookImages.Add(imgLink);
    bookImages.Add(imgLinkSm);
    var desc = new BookDesc
    {
        Description = @"Новый роман самой яркой дебютантки в истории российской литературы новейшего времени, лауреата премий «Большая книга» и «Ясная Поляна» за бестселлер «Зулейха открывает глаза».",
        PagesCount = 496,
        Price = "845 RUB",
        DownloadLinks = new List<DownloadLink> {epub, pdf}
    };
    var book = new Book
    {
        Name = "Дети мои",
        Language = "ru",
        PublishedDate = "01.05.2018",
        IsForAdult = false,
        IsPaid = true,
        ImgLinks = bookImages,
        Description = desc,
        Ratings = new List<Rating>() {rating}
    };
    rating.Book = book;
    db.Ratings.Add(rating);
    
    var smallImageAuthor =
        @"https://leearusia.info/upload/iblock/325/4.jpg";
    var bigImageAuthor =
        @"https://leearusia.info/upload/iblock/325/4.jpg";
    var imgLinkSmAuthor = new ImgLink { Resolution = "smallThumbnail", Url = smallImageAuthor != null && bigImageAuthor != null ? smallImageAuthor : "" };
    var imgLinkAuthor = new ImgLink { Resolution = "thumbnail",  Url = smallImageAuthor != null && bigImageAuthor != null ? bigImageAuthor : "" };

    
    List<Author> authors = new List<Author>();
    authors.Add(new Author
        {
            Name = "Гузель Яхина",
            BirthDate = "1.06.1977",
            ImgLinks = new List<ImgLink>{imgLinkAuthor, imgLinkSmAuthor}
        }
    );

    foreach (var author in authors)
    {
        var dbAuthor = db.Authors.FirstOrDefault(a => a.Name == author.Name);
        if (dbAuthor == null)
        {
            db.Authors.Add(author);
            authorBooks.Add(new AuthorBook
            {
                Author = author,
                Book = book
            });
        }
        else
        {
            authorBooks.Add(new AuthorBook {Author = dbAuthor, Book = book});
        }
    }

    book.AuthorBooks = authorBooks;
    
    bookGenres.Add(new BookGenre
    {
        Genre = db.Genres.Where(g => g.Name=="Fiction")?.FirstOrDefault(),
        Book = book
    });
    
    db.BookGenres.AddRange(bookGenres);
    db.SaveChanges();
}

#endregion


#region AddSubscr

using (var db = new MyBookContext())
{
    var type = new Type
    {
        TypeName = "Премиум",
        Price = 899,
        Description = "Доступ ко всем книгам без ограничений",
    };
    var type1 = new Type
    {
        TypeName = "Подписка на автора",
        Price = 399,
        Description = "Выберите автора и получите доступ ко всем его произведениям",
    };
    var type2 = new Type
    {
        TypeName = "Подписка на жанр",
        Price = 399,
        Description = "Выберите жанр и получите доступ ко всем произведениям, относящимся к нему",
    };
    db.Types.AddRange(type, type1, type2);
    db.SaveChanges();
}

#endregion


#region AddBookCenters

using (var db = new MyBookContext())
{
    //regex for phone ^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$
    var center = new BookCenter
    {
        Name = "My Book Kazan Ямашева",
        Address = "г.Казань, пр-т. Ямашева, дом 15/2 этаж 4",
        Phone = "8-967-777-96-11",
        Description = "Почта: MyBook.kazan@gmail.com",
        Latitude = 55.826190,
        Longitude = 49.097143
    };
    var center1 = new BookCenter
    {
        Name = "My Book Moscow",
        Address = "г.Москва, пр-т. Победы 92/4",
        Phone = "8-905-557-23-11",
        Description = "Почта: MyBook.moscow@gmail.com",
        Latitude = 55.689319,
        Longitude = 37.912552
    };
    var center2 = new BookCenter
    {
        Name = "My Book Kazan Декабристов",
        Address = "г.Казань, ул. Декабристов 182",
        Phone = "(843) 563 17 90",
        Description = "Почта: info@kazanbooks.ru. Предлагаем самый большой выбор учебной литературы.",
        Latitude = 55.840659,
        Longitude = 49.082366
    };
    db.BookCenters.AddRange(center, center1, center2);
    db.SaveChanges();
}

#endregion
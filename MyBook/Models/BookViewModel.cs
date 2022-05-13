﻿using Microsoft.AspNetCore.Identity;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

namespace MyBook.Models;

public class BookViewModel
{
    private readonly EfBookRepository _bookRepository;
    private readonly IGenericRepository<Author> _authorRepository;
    private readonly IGenericRepository<MyBook.Entities.Type> _typeRepository;
    private readonly IGenericRepository<Genre> _genreRepository;
    public readonly Book? _resultBook;
    public User? User;
    private readonly UserManager<User> _userManager;
    private string userId;
    public List<DownloadLink> downloadLink;
    public IGenericRepository<DownloadLink> _linksRepository;

    public BookViewModel(IGenericRepository<DownloadLink> linksRepository,
        IGenericRepository<MyBook.Entities.Type> typeRepository, EfBookRepository bookRepository, int bookId, User user)
    {
        _linksRepository = linksRepository;
        _typeRepository = typeRepository;
        _bookRepository = bookRepository;
        _resultBook = _bookRepository.GetFullBook(bookId);
        User = user;
        downloadLink = linksRepository.GetWithInclude(link =>
            _resultBook.BookDescId == link.BookDescId).ToList();
    }

    public bool HasPremiumSubscription()
    {
        var type = GetTypes().First(it => it.TypeName == "Премиум");
        var user = HasSubscription(type.TypeId, null, null);
        return user.Result != null;
    }

    public bool HasGenreSubsciption()
    {
        int genreId;
        genreId = _resultBook.BookGenres.First().Genre.GenreId;
        var type = GetTypes().First(it => it.TypeName == "Подписка на жанр");
        var user = HasSubscription(type.TypeId, genreId: genreId, authorId: null);
        return user.Result != null;
    }

    public bool IsPermitted()
    {
        return _resultBook.IsPaid == false || HasGenreSubsciption() || HasAuthorSubscription() 
            || HasPremiumSubscription();
    }

    public bool HasAuthorSubscription()
    {
        int authorId;
        if (_resultBook.AuthorBooks.Count == 0) return false;
        authorId = _resultBook.AuthorBooks.First().Author.AuthorId;
        var type = GetTypes().First(it => it.TypeName == "Подписка на автора");
        var user = HasSubscription(type.TypeId, genreId: null, authorId: authorId);
        return user.Result != null;
    }

    private async Task<User?> HasSubscription(int typeId, int? genreId, int? authorId)
    {
        if (User == null)
            return null;
        if (User.UserSubscrs != null && (User.UserSubscrs.Any(it =>
                it.Subscription.TypeId == typeId &&
                ((genreId != null && it.Subscription.GenreId == genreId) ||
                 (authorId != null && it.Subscription.AuthorId == authorId) 
                 || it.Subscription.Type.TypeName=="Премиум"))))
            return User;
        return null;
    }


    private List<MyBook.Entities.Type> GetTypes()
    {
        return _typeRepository.Get().ToList();
    }
}
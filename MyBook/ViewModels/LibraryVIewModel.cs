﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using Repositories;


namespace MyBook.ViewModels
{
    public class LibraryVIewModel
    {
        public List<Book> AllBooks { get; set; } 
        public List<Author> AllAuthors { get; set; }
        public List<Genre> AllGenres { get; set; }

        private readonly IGenericRepository<Book> _bookRepository;
        
        private readonly string _filter;
        public List<Book> Books { get; set; } = new();

        public  List<SelectListItem> Languages = new List<SelectListItem>();
        public  List<SelectListItem> Genres = new List<SelectListItem>();

        private List<Book> GetFilterBooks()
        {
            return _bookRepository.GetWithMultiIncluding(
                book => book,
                book => book.Language.EndsWith(_filter),
                        books =>
                    books.Include(book => book.AuthorBooks)
                        .ThenInclude(authorBook => authorBook.Author)
                        .Include(book => book.ImgLinks)
                        .Include(book => book.Description)
            ).ToList();
        }
        

        public LibraryVIewModel(
            IGenericRepository<Book> bookRepository,
            IGenericRepository<Author> authorRepository,
            IGenericRepository<Genre> genreRepository,
            string filter)
        {
            _bookRepository = bookRepository;
            _filter = filter;
            AllBooks = GetFilterBooks();
            AllAuthors = GetAllAuthors(authorRepository);
            AllGenres = genreRepository.Get().ToList();
            Books = GetFilterBooks();
            Languages = GetLanguages();
            Genres = GetGenres();
        }
        
        public LibraryVIewModel(
            IGenericRepository<Book> bookRepository,
            IGenericRepository<Author> authorRepository,
            IGenericRepository<Genre> genreRepository)
        {
            _bookRepository = bookRepository;
            AllBooks = GetAllBooks(bookRepository);
            AllAuthors = GetAllAuthors(authorRepository);
            AllGenres = genreRepository.Get().ToList();
            Books = GetFilterBooks();
            Languages = GetLanguages();
            Genres = GetGenres();
        }


        private List<SelectListItem> GetLanguages()
        {
            Languages.Add(new SelectListItem() {Text = "Все", Value = "Все"});
            List<Book> allBooks = GetAllBooks(_bookRepository);
            List<string> languages = new List<string>();
            foreach (var book in allBooks)
            {
                if (!languages.Contains(book.Language))
                {
                    languages.Add(book.Language);
                }
            }
            foreach (var lang in languages)
            {
                var item = new SelectListItem() {Text = $"{lang}", Value = $"{lang}"};
                Languages.Add(item);
            }
            return Languages;
        }
        
        private List<SelectListItem> GetGenres()
        {
           Genres.Add(new SelectListItem() {Text = "Все", Value = "Все"});
           foreach (var genre in AllGenres)
           {
               var genreName = genre.Name;
               var item = new SelectListItem() {Text = $"{genreName}", Value = $"{genreName}"};
               Genres.Add(item);
           }

           return Genres;
        } 
        
        private List<Book> GetAllBooks(IGenericRepository<Book> bookRepository)
        {
            return bookRepository.GetWithMultiIncluding(
                book => book,
                book => true,
                books =>
                    books.Include(book => book.AuthorBooks)
                        .ThenInclude(authorBook => authorBook.Author)
                        .Include(book => book.ImgLinks)

            ).ToList();
        }

        private List<Author> GetAllAuthors(IGenericRepository<Author> authorRepository)
        {
            return authorRepository.GetWithMultiIncluding(
                author => author,
                author => true,
                authors =>
                    authors.Include(author => author.AuthorBooks)
                        .ThenInclude(authorBook => authorBook.Book)
                        .Include(author => author.ImgLinks)
            ).ToList();
        }
    }
}
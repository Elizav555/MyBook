using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using Repositories;

namespace MyBook.ViewModels;

public class LibraryVIewModel
{
    public List<Book> AllBooks { get; set; }
    public List<Author> AllAuthors { get; set; }
    public List<Genre> AllGenres { get; set; }

    public LibraryVIewModel(
        IGenericRepository<Book> bookRepository,
        IGenericRepository<Author> authorRepository,
        IGenericRepository<Genre> genreRepository)
    {
        AllBooks = GetAllBooks(bookRepository);
        AllAuthors = GetAllAuthors(authorRepository);
        AllGenres = genreRepository.Get().ToList();
    }

    private List<Book> GetAllBooks(IGenericRepository<Book> bookRepository)
    {
        return bookRepository.GetWithMultiIncluding(
            book => book,
            book => true,
            books => 
                books.Include(book => book.AuthorBooks)
                    .ThenInclude(authorBook =>  authorBook.Author)
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
                    .ThenInclude(authorBook =>  authorBook.Book)
                    .Include(author => author.ImgLinks)
        ).ToList();
    }
}
using Microsoft.EntityFrameworkCore;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using Repositories;

namespace MyBook.ViewModels;

public class LibraryViewModel
{
    public List<Book> AllBooks { get; set; }
    public List<Author> AllAuthors { get; set; }

    public LibraryViewModel(
        EfBookRepository bookRepository,
        EfAuthorRepository authorRepository)
    {
        AllBooks = bookRepository.GetAllBooks().ToList();
        AllAuthors = authorRepository.GetAllAuthors().ToList();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using MyBook.Models.Admin;
using Repositories;
using Type = MyBook.Entities.Type;
namespace MyBook.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class AdminProfileController : Controller
    {
        private readonly IGenericRepository<Type> _typeRepository;
        private readonly EfAuthorRepository _authorRepository;
        private readonly EfBookRepository _bookRepository;
        private readonly EFBookCenterRepository _bookCenterRepository;
        private readonly EFUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;

        public AdminProfileController(IGenericRepository<Type> typeRep,
        EfAuthorRepository authorRepository,
            EfBookRepository bookRepository,
             EFBookCenterRepository bookCenterRepository,
            EFUserRepository userRepository,
            SignInManager<User> signInManager)
        {
            _typeRepository = typeRep;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookCenterRepository = bookCenterRepository;
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(new AdminViewModel
            {
                Authors = GetAuthors(),
                Books = GetBooks(),
                Centers = GetCenters(),
                SubscrTypes = GetTypes(),
                Users = GetUsers()
            });
        }

        public IActionResult ShowCurrent(string page)
        {
            return View("Index", new AdminViewModel
            {
                Authors = GetAuthors(),
                Books = GetBooks(),
                Centers = GetCenters(),
                SubscrTypes = GetTypes(),
                Users = GetUsers(),
                CurrentPage = page
            });
        }
        #region SubscrType
        public async Task<IActionResult> DeleteSubscrType(Type type)
        {
            await _typeRepository.Remove(type);
            var page = "Subscription";
            return RedirectToAction("ShowCurrent", new { page });
        }

        public async Task<IActionResult> AddSubscrType()
        {
            //TODO 
            var page = "Subscription";
            return RedirectToAction("ShowCurrent", new { page });
        }
        public async Task<IActionResult> EditSubscrType()
        {
            //TODO 
            var page = "Subscription";
            return RedirectToAction("ShowCurrent", new { page });
        }

        #endregion

        #region Author
        //TODO search author
        public async Task<IActionResult> DeleteAuthor(Author author)
        {
            await _authorRepository.Remove(author);
            var page = "Author";
            return RedirectToAction("ShowCurrent", new { page });
        }

        public async Task<IActionResult> AddAuthor()
        {
            //TODO 
            var page = "Author";
            return RedirectToAction("ShowCurrent", new { page });
        }
        public async Task<IActionResult> EditAuthor()
        {
            //TODO 
            var page = "Author";
            return RedirectToAction("ShowCurrent", new { page });
        }

        #endregion

        #region Book
        //TODO search book
        public async Task<IActionResult> DeleteBook(Book book)
        {
            await _bookRepository.Remove(book);
            var page = "Book";
            return RedirectToAction("Index", new { page });
        }

        public async Task<IActionResult> AddBook()
        {
            //TODO 
            var page = "Book";
            return RedirectToAction("Index", new { page });
        }
        public async Task<IActionResult> EditBook()
        {
            //TODO 
            var page = "Book";
            return RedirectToAction("Index", new { page });
        }

        #endregion

        #region BookCenter
        public async Task<IActionResult> DeleteBookCenter(BookCenter bookCenter)
        {
            await _bookCenterRepository.Remove(bookCenter);
            var page = "BookCenter";
            return RedirectToAction("ShowCurrent", new { page });
        }

        public async Task<IActionResult> AddBookCenter()
        {
            //TODO 
            var page = "BookCenter";
            return RedirectToAction("ShowCurrent", new { page });
        }
        public async Task<IActionResult> EditBookCenter()
        {
            //TODO 
            var page = "BookCenter";
            return RedirectToAction("ShowCurrent", new { page });
        }

        #endregion

        #region User
        //TODO search User
        public async Task<IActionResult> DeleteUserSubscr(string userId, Subscription subscription)
        {
            //TODO
            var page = "User";
            return RedirectToAction("ShowCurrent", new { page });
        }

        public async Task<IActionResult> AddUserSubscr()
        {
            //TODO 
            var page = "User";
            return RedirectToAction("ShowCurrent", new { page });
        }
        #endregion

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private List<Type> GetTypes()
        {
            return _typeRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            return _authorRepository.GetAllAuthors().ToList();
        }

        private List<Book> GetBooks()
        {
            return _bookRepository.GetAllBooks().ToList();
        }

        private List<User> GetUsers()
        {
            return _userRepository.GetUsersWithSubscr().ToList();
        }

        private List<BookCenter> GetCenters()
        {
            return _bookCenterRepository.Get().ToList();
        }
    }
}
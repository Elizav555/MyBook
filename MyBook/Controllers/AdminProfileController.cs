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
        private readonly IGenericRepository<Object> _genericRepository;
        private readonly SignInManager<User> _signInManager;

        public AdminProfileController(IGenericRepository<Type> typeRep,
        EfAuthorRepository authorRepository,
            EfBookRepository bookRepository,
             EFBookCenterRepository bookCenterRepository,
            EFUserRepository userRepository,
            IGenericRepository<object> genericRepository,
            SignInManager<User> signInManager)
        {
            _typeRepository = typeRep;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookCenterRepository = bookCenterRepository;
            _genericRepository = genericRepository;
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

        public IActionResult EditSubscriptionModal(EditSubscrViewModel model)
        {
            return View(model);
        }

        public IActionResult AddSubscriptionModal(EditSubscrViewModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> AddSubscrType(EditSubscrViewModel model)
        {
            if (ModelState.IsValid)
            {
                var type = new Type { Description = model.Description, Price = model.Price, TypeName = model.TypeName };
                await _typeRepository.Create(type);
                var page = "Subscription";
                return RedirectToAction("ShowCurrent", new { page });
            }
            return View("AddSubscriptionModal", model);
        }

        public async Task<IActionResult> EditSubscrType(EditSubscrViewModel model)
        {
            if (ModelState.IsValid && model.TypeId != null)
            {
                var type = await _typeRepository.FindById((int)model.TypeId);
                if (type == null)
                {
                    ModelState.AddModelError("TypeNotFound", "Тип с таким айди не был найден");
                    return View("EditSubscriptionModal", model);
                }
                type.Description = model.Description;
                type.Price = model.Price;
                type.TypeName = model.TypeName;
                await _typeRepository.Update(type, null);
                var page = "Subscription";
                return RedirectToAction("ShowCurrent", new { page });
            }
            return View("EditSubscriptionModal", model);
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
        public IActionResult EditAuthorModal(EditAuthorViewModel model)
        {
            return View(model);
        }

        public IActionResult AddAuthorModal(EditAuthorViewModel model)
        {
            return View(model);
        }

        public async Task<IActionResult> AddAuthor(EditAuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = new Author { Name = model.Name, BirthDate = model.BirthDate?.ToShortDateString(), ImgLinks = new List<ImgLink>() };
                if (model.ImageLink != null)
                {
                    var imageLink = new ImgLink { AuthorId = author.AuthorId, Url = model.ImageLink };
                    author.ImgLinks.Add(imageLink);
                    await _genericRepository.CreateAll(new List<object>() { author, imageLink });
                }
                else await _authorRepository.Create(author);
                var page = "Author";
                return RedirectToAction("ShowCurrent", new { page });
            }
            return View("AddAuthorModal", model);
        }

        public async Task<IActionResult> EditAuthor(EditAuthorViewModel model)
        {
            if (ModelState.IsValid && model.AuthorId != null)
            {
                var author = await _authorRepository.FindById((int)model.AuthorId);
                if (author == null)
                {
                    ModelState.AddModelError("AuthorNotFound", "Автор с таким айди не был найден");
                    return View("EditAuthorModal", model);
                }
                author.Name = model.Name;
                if (model.BirthDate != null)
                    author.BirthDate = model.BirthDate?.ToShortDateString();
                if (model.ImageLink != null)
                {
                    var imageLink = new ImgLink { AuthorId = author.AuthorId, Url = model.ImageLink };
                    await _genericRepository.CreateAll(new List<object>() { imageLink });
                    author.ImgLinks = new List<ImgLink> { imageLink };
                }
                await _authorRepository.Update(author, null);
                var page = "Author";
                return RedirectToAction("ShowCurrent", new { page });
            }
            return View("EditAuthorModal", model);
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
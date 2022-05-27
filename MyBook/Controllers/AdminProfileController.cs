using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using MyBook.Models.Admin;
using Repositories;
using System.Globalization;
using System.Security.Claims;
using Type = MyBook.Entities.Type;
namespace MyBook.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class AdminProfileController : Controller
    {
        private readonly IGenericRepository<Type> _typeRepository;
        private readonly EfAuthorRepository _authorRepository;
        private readonly EFGenreRepository _genreRepository;
        private readonly EfBookRepository _bookRepository;
        private readonly EFBookCenterRepository _bookCenterRepository;
        private readonly EFUserRepository _userRepository;
        private readonly EFUserSubscrRepository _userSubscrRepository;
        private readonly IGenericRepository<Object> _genericRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AdminProfileController(IGenericRepository<Type> typeRep,
        EfAuthorRepository authorRepository,
        EFGenreRepository genreRepository,
            EfBookRepository bookRepository,
             EFBookCenterRepository bookCenterRepository,
            EFUserRepository userRepository,
            IGenericRepository<object> genericRepository,
            EFUserSubscrRepository userSubscrRepository,
        SignInManager<User> signInManager,
        UserManager<User> userManager)
        {
            _typeRepository = typeRep;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookCenterRepository = bookCenterRepository;
            _genericRepository = genericRepository;
            _userRepository = userRepository;
            _signInManager = signInManager;
            _userSubscrRepository = userSubscrRepository;
            _genreRepository = genreRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(new AdminViewModel
            {
                Authors = GetAuthors(),
                Books = GetBooks(),
                Centers = GetCenters(),
                SubscrTypes = GetTypes(),
                Users = await GetUsers()
            });
        }

        public async Task<IActionResult> ShowCurrent(string page)
        {
            return View("Index", new AdminViewModel
            {
                Authors = GetAuthors(),
                Books = GetBooks(),
                Centers = GetCenters(),
                SubscrTypes = GetTypes(),
                Users = await GetUsers(),
                CurrentPage = page
            });
        }

        #region SubscrType
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Subscription" };
            var type = await _typeRepository.FindById(id);
            if (type == null)
            {
                return RedirectToAction("Error", "Modals", modalModel);
            }
            await _typeRepository.Remove(type);
            return RedirectToAction("Successful", "Modals", modalModel);
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
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Subscription" };
                return RedirectToAction("Successful", "Modals", modalModel);
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
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Subscription" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("EditSubscriptionModal", model);
        }

        #endregion

        #region Author
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Author" };
            var author = await _authorRepository.FindById(id);
            if (author == null)
                return RedirectToAction("Error", "Modals", modalModel);
            await _authorRepository.Remove(author);
            return RedirectToAction("Successful", "Modals", modalModel);
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
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Author" };
                return RedirectToAction("Successful", "Modals", modalModel);
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
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Author" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("EditAuthorModal", model);
        }

        #endregion

        #region Book
        public async Task<IActionResult> DeleteBook(int id)
        {
            var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Book" };
            var book = await _bookRepository.FindById(id);
            if (book == null)
                return RedirectToAction("Error", "Modals", modalModel);
            await _bookRepository.Remove(book);
            return RedirectToAction("Successful", "Modals", modalModel);
        }

        public IActionResult EditBookModal(EditBookViewModel model)
        {
            model.Genres = GetGenres();
            model.Authors = GetAuthors();
            return View(model);
        }

        public IActionResult AddBookModal()
        {
            var model = new MyBook.Models.Admin.EditBookViewModel { Genres = GetGenres(), Authors = GetAuthors() };
            return View(model);
        }

        public async Task<IActionResult> AddBook(EditBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                await AddBookPrivate(model);
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Book" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("AddBookModal", model);
        }

        private async Task AddBookPrivate(EditBookViewModel model)
        {
            var book = new Book { Name = model.Name, ImgLinks = new List<ImgLink>(), IsForAdult = model.IsForAdult, IsPaid = model.IsPaid, PublishedDate = model.PublishedDate, Language = model.Language };
            var entities = new List<object>();
            if (model.GenreName != null)
            {
                var genreId = _genreRepository.Get(it => it.Name == model.GenreName).FirstOrDefault()?.GenreId;
                if (genreId != null)
                {
                    var bookGenre = new BookGenre { Book = book, GenreId = (int)genreId };
                    entities.Add(bookGenre);
                    book.BookGenres.Add(bookGenre);
                }
            }
            if (model.AuthorName != null)
            {
                var authorId = _authorRepository.Get(it => it.Name == model.AuthorName).FirstOrDefault()?.AuthorId;
                if (authorId != null)
                {
                    var bookAuthor = new AuthorBook { Book = book, AuthorId = (int)authorId };
                    book.AuthorBooks.Add(bookAuthor);
                    entities.Add(bookAuthor);
                }
            }
            var desc = new BookDesc { Description = model.Description, DownloadLinks = new List<DownloadLink>(), PagesCount = model.PagesCount != null ? (int)model.PagesCount : 0, Price = model.Price, Book = book };
            book.Description = desc;
            if (model.ImageLink != null)
            {
                var imageLink = new ImgLink { Book = book, Url = model.ImageLink, Resolution = "thumbnail" };
                book.ImgLinks.Add(imageLink);
                entities.Add(imageLink);
            }

            if (!string.IsNullOrEmpty(model.UrlPDF))
            {
                var pdfLink = new DownloadLink { BookDesc = desc, Format = "pdf", Url = model.UrlPDF };
                desc.DownloadLinks.Add(pdfLink);
                entities.Add(pdfLink);
            }
            if (!string.IsNullOrEmpty(model.UrlEPUB))
            {
                var epubLink = new DownloadLink { BookDesc = desc, Format = "epub", Url = model.UrlEPUB };
                desc.DownloadLinks.Add(epubLink);
                entities.Add(epubLink);
            }

            entities.Add(book);
            entities.Add(desc);
            await _genericRepository.CreateAll(entities);
        }

        public async Task<IActionResult> EditBook(EditBookViewModel model)
        {
            if (ModelState.IsValid && model.BookId != null)
            {
                var book = await _bookRepository.FindById((int)model.BookId);
                if (book == null)
                {
                    ModelState.AddModelError("BookNotFound", "Книга с таким айди не был найдена");
                    return View("EditBookModal", model);
                }
                await _bookRepository.Remove(book);
                await AddBookPrivate(model);
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "Book" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("EditBookModal", model);
        }

        #endregion

        #region BookCenter

        public IActionResult EditBookCenterModal(EditCenterViewModel model)
        {
            return View(model);
        }

        public IActionResult AddBookCenterModal()
        {
            return View(new EditCenterViewModel());
        }

        public async Task<IActionResult> DeleteBookCenter(int id)
        {
            var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "BookCenter" };
            var bookCenter = await _bookCenterRepository.FindById(id);
            if (bookCenter == null)
                return RedirectToAction("Error", "Modals", modalModel);
            await _bookCenterRepository.Remove(bookCenter);
            return RedirectToAction("Successful", "Modals", modalModel);
        }

        public async Task<IActionResult> AddBookCenter(EditCenterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var center = new BookCenter { Address = model.Address, Name = model.Name, Description = model.Description, Phone = model.Phone, Latitude = Double.Parse(model.Latitude, CultureInfo.InvariantCulture), Longitude = Double.Parse(model.Longitude, CultureInfo.InvariantCulture) };
                await _bookCenterRepository.Create(center);
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "BookCenter" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("AddBookCenterModal", model);
        }
        public async Task<IActionResult> EditBookCenter(EditCenterViewModel model)
        {

            if (ModelState.IsValid && model.BookCenterId != null)
            {
                var center = await _bookCenterRepository.FindById((int)model.BookCenterId);
                if (center == null)
                {
                    ModelState.AddModelError("CenterNotFound", "Центр с таким айди не был найден");
                    return View("EditBookCenterModal", model);
                }
                center.Name = model.Name;
                center.Address = model.Address;
                center.Description = model.Description;
                center.Phone = model.Phone;
                center.Latitude = Double.Parse(model.Latitude, CultureInfo.InvariantCulture);
                center.Longitude = Double.Parse(model.Longitude, CultureInfo.InvariantCulture);
                await _bookCenterRepository.Update(center, null);
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "BookCenter" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("EditBookCenterModal", model);
        }

        #endregion

        #region User
        public async Task<IActionResult> DeleteUserSubscr(string id, int subscrId)
        {
            var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "User" };
            var userSubscr = _userSubscrRepository.GetUserSubscr(id, subscrId);
            if (userSubscr == null)
                return RedirectToAction("Error", "Modals", modalModel);
            await _userSubscrRepository.Remove(userSubscr);
            return RedirectToAction("Successful", "Modals", modalModel);
        }
        public IActionResult AddSubscrModal(string userId)
        {
            return View("AddSubscriptionToUserModal", new EditUserViewModel { Authors = GetAuthors(), Genres = GetGenres(), SubscrTypes = GetTypes(), UserID = userId });
        }

        public async Task<IActionResult> AddAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
            var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "User" };
            return RedirectToAction("Successful", "Modals", modalModel);
        }


        public async Task<IActionResult> AddUserSubscr(EditUserViewModel model)
        {
            model.Authors = GetAuthors();
            model.Genres = GetGenres();
            model.SubscrTypes = GetTypes();
            if (ModelState.IsValid)
            {
                var type = GetTypes().First(it => it.TypeId == model.TypeId);
                var subscr = new Subscription
                {
                    StartDate = DateTime.Now.ToString(),
                    EndDate = DateTime.Now.AddMonths((int)model.Period).ToString(),
                    TypeId = (int)model.TypeId,
                };
                if (type.TypeName == "Подписка на автора")
                {
                    if (model.AuthorName != null)
                    {
                        var author = _authorRepository.Get(it => it.Name == model.AuthorName).FirstOrDefault();
                        if (author == null)
                            return View("AddSubscriptionToUserModal", model);
                        subscr.AuthorId = author.AuthorId;
                    }
                    else
                    {
                        ModelState.AddModelError("AuthorName", "Укажите автора для подписки");
                        return View("AddSubscriptionToUserModal", model);
                    }
                }
                if (type.TypeName == "Подписка на жанр")
                {
                    if (model.GenreName != null)
                    {
                        var genre = _genreRepository.Get(it => it.Name == model.GenreName).FirstOrDefault();
                        if (genre == null)
                            return View("AddSubscriptionToUserModal", model);
                        subscr.GenreId = genre.GenreId;
                    }
                    else
                    {
                        ModelState.AddModelError("GenreName", "Укажите жанр для подписки");
                        return View("AddSubscriptionToUserModal", model);
                    }
                }
                var userSubscr = new UserSubscr { Subscription = subscr, UserId = model.UserID };
                subscr.UserSubscr = userSubscr;
                await _genericRepository.CreateAll(new List<object>() { subscr, userSubscr, });
                var modalModel = new ModalsViewModel { ControllerName = "AdminProfile", ActionName = "ShowCurrent", CurrentPage = "User" };
                return RedirectToAction("Successful", "Modals", modalModel);
            }
            return View("AddSubscriptionToUserModal", model);
        }

        #endregion

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #region GetData

        private List<Type> GetTypes()
        {
            return _typeRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            ViewData["haveAuthors"] = true;
            return _authorRepository.GetAllAuthors().ToList();
        }

        private List<Book> GetBooks()
        {
            ViewData["haveBooks"] = true;
            return _bookRepository.GetAllBooks().ToList();
        }

        private async Task<List<User>> GetUsers()
        {
            ViewData["haveUsers"] = true;
            var admins = await _userManager.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "Admin"));
            return _userRepository.GetUsersWithSubscr().Where(user => !admins.Contains(user)).ToList();
        }

        private List<BookCenter> GetCenters()
        {
            return _bookCenterRepository.Get().ToList();
        }

        private List<Genre> GetGenres()
        {
            return _genreRepository.Get().ToList();
        }
        #endregion
    }
}

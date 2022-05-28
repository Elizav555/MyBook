using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Core.Validation;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using MyBook.SharedKernel.SharedHelpers;
using Repositories;


namespace MyBook.Controllers
{
    public class BookController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly EfBookRepository _bookRepository;
        private readonly EFUserRepository _userRepository;
        private readonly EFHistoryRepository _historyRepository;
        private readonly IGenericRepository<MyBook.Entities.Type> _typeRepository;
        private BookViewModel _viewModel;
        private readonly IGenericRepository<DownloadLink> _linksRepository;
        private readonly IGenericRepository<Rating> _ratingsRepository;
        
        public BookController(EfBookRepository bookRepository,
            EFUserRepository userRepository,
            EFTypeRepository typeRepository,
            IGenericRepository<DownloadLink> linksRepository,
            IGenericRepository<Rating> ratingsRepository,
            EFHistoryRepository historyRepository,
            UserManager<User> userManager)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;
            _linksRepository = linksRepository;
            _ratingsRepository = ratingsRepository;
            _historyRepository = historyRepository;
            _userManager = userManager;
        }

        // GET
        [Route("Book/{bookId:int}")]
        public IActionResult Book(int bookId)
        {
            _viewModel = new BookViewModel(_historyRepository, _linksRepository,
                _typeRepository, _bookRepository, bookId, CheckUser());
            return View(_viewModel);
        }

        private User? CheckUser()
        {
            var user = _userRepository.GetUserWithSubscr(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
                return null;
            return user;
        }

        [Authorize]
        public async Task<IActionResult> DownloadFile(string link, string name, string format, int bookId)
        {
            if (name == null || link == null || format == null)
                return RedirectToAction("Book", "Book", new {bookId});
            var user = CheckUser();
            var contentType = "APPLICATION/octet-stream";
            var fileName = name + "." + format;
            var book = _bookRepository.GetFullBook(bookId);
            if (user == null || book == null)
            {
                var modalModel = new ModalsViewModel { ControllerName = "Book", ActionName = "Book", BookId = bookId };
                return RedirectToAction("Error", "Modals", modalModel);
            }
            var history = new History
            {
                BookId = bookId,
                DateTime = DateTime.Now.ToString(),
                UserId = user.Id,
            };
            book.DownloadsCount += 1;
            await _bookRepository.Update(book);
            if (!_historyRepository.CheckHistory(user.Id, bookId))
                await _historyRepository.Create(history);
            var stream = await new HttpClient().GetStreamAsync(link);
            return new FileStreamResult(stream, contentType)
            {
                FileDownloadName = fileName,
            };
        }

        public async Task<IActionResult> PostComment(int rating, string comment, int bookId)
        {
            if (!Validator.LettersAndSpaces.IsMatch(comment))
            {
                return BadRequest();
            }
            var returnComment = new Rating();
            var user = await _userManager.GetUserAsync(User);
            var bookRatings = _bookRepository.GetWithInclude(book => book.BookId == bookId, book => book.Ratings)
                .First().Ratings;
            var newComment = new Rating()
            {
                Points = rating,
                ReviewText = comment,
                Book = _bookRepository.FindById(bookId).Result,
                BookId = bookId,
                User = user,
                UserId = user.Id
            };
            if (CollectionHelper<Rating>.Contains(bookRatings, rating1 => rating1.UserId == user.Id))
            {
                var currentRating = bookRatings.First(rating1 => rating1.UserId == user.Id);
                currentRating.Points = rating;
                currentRating.ReviewText = comment;
                await _ratingsRepository.Update(currentRating, null);
            }
            else
            {
                await _ratingsRepository.Create(newComment);
            }

            return PartialView("../Partials/_Comment", newComment);
        }
    }
}
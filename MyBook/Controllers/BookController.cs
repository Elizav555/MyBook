using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using Repositories;


namespace MyBook.Controllers
{
    public class BookController : Controller
    {
        private readonly EfBookRepository _bookRepository;
        private readonly EFUserRepository _userRepository;
        private readonly EFHistoryRepository _historyRepository;
        private readonly IGenericRepository<MyBook.Entities.Type> _typeRepository;
        private BookViewModel _viewModel;
        private readonly IGenericRepository<DownloadLink> _linksRepository;

        public BookController(EfBookRepository bookRepository,
            EFUserRepository userRepository,
            EFTypeRepository typeRepository, IGenericRepository<DownloadLink> linksRepository,
            EFHistoryRepository historyRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;
            _linksRepository = linksRepository;
            _historyRepository = historyRepository;
        }


        // GET
        [Route("Book/{bookId:int}")]
        public IActionResult Book(int bookId)
        {
            _viewModel = new BookViewModel(_linksRepository,
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


        public async Task<IActionResult> DownloadFile(string link, string name, string format, int bookId)
        {
            format = "acsm";
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = name + "." + format;
            var user = CheckUser();
            var book = _bookRepository.GetFullBook(bookId);
            if (user == null || book == null)
                return RedirectToAction("error");//TODO show error
            var history = new History
            {
                BookId = bookId,
                DateTime = DateTime.Now.ToString(),
                UserId = user.Id,
            };
            book.DownloadsCount += 1;
            await _bookRepository.Update(book);
            await _historyRepository.Create(history);
            return File(content, contentType, fileName);
        }
    }
}
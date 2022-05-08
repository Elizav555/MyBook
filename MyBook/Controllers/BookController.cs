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
        private readonly IGenericRepository<MyBook.Entities.Type> _typeRepository;
        private BookViewModel _viewModel;
        private readonly IGenericRepository<DownloadLink> _linksRepository;

        public BookController(EfBookRepository bookRepository,
            EFUserRepository userRepository,
            EFTypeRepository typeRepository, IGenericRepository<DownloadLink> linksRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _typeRepository = typeRepository;
            _linksRepository = linksRepository;
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


        public async Task<IActionResult> DownloadFile(string link, string name, string format)
        {
            format = "acsm";
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = name + "." + format;
            return File(content, contentType, fileName);
        }
    }
}
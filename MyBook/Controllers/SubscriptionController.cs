using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Models;
using Repositories;

namespace MyBook.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Genre> _genreRepository;


        private readonly UserManager<User> _userManager;

        public SubscriptionController(IGenericRepository<Author> authorRepository,
                                            IGenericRepository<Genre> genreRepository, UserManager<User> userManager)
        {
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Subscription()
        {
            return View(new BuySubscrViewModel { Genres = GetGenres(), Authors = GetAuthors() });
        }

        [HttpPost]
        public IActionResult SubscrForGenre(string GenreName)
        {
            //var subscr = new Subscription { StartDate = DateTime.Now.ToString(), EndDate = DateTime.Now.AddMonths(1).ToString(), }
            return View();
        }

        private List<Genre> GetGenres()
        {
            return _genreRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            return _authorRepository.Get().ToList();
        }
    }
}
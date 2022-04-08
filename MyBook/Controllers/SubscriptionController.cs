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

        public SubscriptionController(IGenericRepository<Author> authorRepository,
                                            IGenericRepository<Genre> genreRepository)
        {
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public IActionResult Subscription()
        {
            return View(new BuySubscrViewModel { Genres = GetGenres(), Authors = GetAuthors() });
        }

        [HttpPost]
        public IActionResult SubscrForGenre(string GenreName)
        {
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.Title.Contains(searchString));
            //}

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
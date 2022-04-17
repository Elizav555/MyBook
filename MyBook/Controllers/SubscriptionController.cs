using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using Repositories;
using System.Security.Claims;

namespace MyBook.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IGenericRepository<MyBook.Entities.Type> _typeRepository;
        private readonly IGenericRepository<Object> _genericRepository;
        private readonly UserManager<User> _userManager;


        public SubscriptionController(IGenericRepository<Author> authorRepository, IGenericRepository<Genre> genreRepository,
            IGenericRepository<MyBook.Entities.Type> typeRepository, IGenericRepository<Object> genericRepository,
            UserManager<User> userManager)
        {
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _typeRepository = typeRepository;
            _genericRepository = genericRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Subscription()
        {
            return View(new BuySubscrViewModel { Genres = GetGenres(), Authors = GetAuthors(), SubscrTypes = GetTypes() });
        }

        [HttpGet]
        public IActionResult SubscrForAuthor()
        {
            return RedirectToAction("Subscription");
        }

        [HttpGet]
        public IActionResult SubscrForGenre()
        {
            return RedirectToAction("Subscription");
        }

        [Authorize(Policy = "ReadersOnly")]
        [HttpPost]
        public async Task<IActionResult> SubscrForGenre(string GenreName)
        {
            var type = GetTypes().First(it => it.TypeName == "Подписка на жанр");
            var genre = _genreRepository.Get(it => it.Name == GenreName);
            var subscr = new Subscription
            {
                StartDate = DateTime.Now.ToString(),
                EndDate = DateTime.Now.AddMonths(1).ToString(),
                TypeId = type.TypeId,
                GenreId = genre.First().GenreId
            };
            var userSubscr = new UserSubscr { Subscription = subscr, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            subscr.UserSubscr = userSubscr;
            await _genericRepository.CreateAll(new List<object>() { subscr, userSubscr, });
            return RedirectToAction("Subscription");
        }

        [Authorize(Policy = "ReadersOnly")]
        [HttpPost]
        public async Task<IActionResult> SubscrForAuthor(string AuthorName)
        {
            var type = GetTypes().First(it => it.TypeName == "Подписка на автора");
            var author = _authorRepository.Get(it => it.Name == AuthorName);
            var subscr = new Subscription
            {
                StartDate = DateTime.Now.ToString(),
                EndDate = DateTime.Now.AddMonths(1).ToString(),
                TypeId = type.TypeId,
                AuthorId = author.First().AuthorId
            };
            var userSubscr = new UserSubscr { Subscription = subscr, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            subscr.UserSubscr = userSubscr;

            await _genericRepository.CreateAll(new List<object>() { subscr, userSubscr, });
            return RedirectToAction("Subscription");
        }

        [Authorize(Policy = "ReadersOnly")]
        public async Task<IActionResult> SubscrForPremium()
        {
            var type = GetTypes().First(it => it.TypeName == "Премиум");
            var subscr = new Subscription
            {
                StartDate = DateTime.Now.ToString(),
                EndDate = DateTime.Now.AddMonths(1).ToString(),
                TypeId = type.TypeId,
            };
            var userSubscr = new UserSubscr { Subscription = subscr, UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            subscr.UserSubscr = userSubscr;
            await _genericRepository.CreateAll(new List<object>() { subscr, userSubscr, });
            return RedirectToAction("Subscription");
        }

        //private async Task<IActionResult> CheckSubscr(Subscription subscr)
        //{
        //    //var user = await _userManager.GetUserAsync(User);
        //    //if (user == null)
        //    //    return null;
        //    //if (user.UserSubscrs.Any(it => it.Subscription.Type == subscr.Type && it.Subscription. ))
        //}

        private List<Genre> GetGenres()
        {
            return _genreRepository.Get().ToList();
        }

        private List<MyBook.Entities.Type> GetTypes()
        {
            return _typeRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            return _authorRepository.Get().ToList();
        }
    }
}
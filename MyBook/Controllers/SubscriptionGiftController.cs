using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Core.Interfaces;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using Repositories;
using Type = MyBook.Entities.Type;

namespace MyBook.Controllers
{
    public class SubscriptionGiftController : Controller
    {
        private readonly IGenericRepository<Type> _typeRepository;
        private readonly EfAuthorRepository _authorRepository;
        private readonly EFGenreRepository _genreRepository;
        private readonly IGenericRepository<Object> _genericRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMailService _mailService;

        public SubscriptionGiftController(
            IGenericRepository<Type> typeRepository, EfAuthorRepository authorRepository,
          EFGenreRepository genreRepository, IGenericRepository<Object> genericRepository,
          UserManager<User> userManager, IMailService mailService)
        {
            _typeRepository = typeRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _genericRepository = genericRepository;
            _userManager = userManager;
            _mailService = mailService;
        }

        public IActionResult SubscriptionGift()
        {
            return View(new GiftViewModel { Authors = GetAuthors(), Genres = GetGenres(), SubscrTypes=GetTypes()});
        }

        //TODO добавить видимость оплаты
        [HttpPost]
        public async Task<IActionResult> SubscriptionGift(GiftViewModel model)
        {
            model.Authors = GetAuthors();
            model.Genres = GetGenres();
            model.SubscrTypes = GetTypes();
            if (ModelState.IsValid)
            {
                var user = await GetUser(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "К сожалению, пользователь с таким email не найден");
                    return View(model);
                }
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
                            return View(model);
                        subscr.AuthorId = author.AuthorId;
                    }
                    else
                    {
                        ModelState.AddModelError("AuthorName", "Укажите автора для подписки");
                        return View(model);
                    }
                }
                if (type.TypeName == "Подписка на жанр")
                {
                    if (model.GenreName != null)
                    {
                        var genre = _genreRepository.Get(it => it.Name == model.GenreName).FirstOrDefault();
                        if (genre == null)
                            return View(model);
                        subscr.AuthorId = genre.GenreId;
                    }
                    else
                    {
                        ModelState.AddModelError("GenreName", "Укажите жанр для подписки");
                        return View(model);
                    }
                }
                var userSubscr = new UserSubscr { Subscription = subscr, UserId = user.Id };
                subscr.UserSubscr = userSubscr;
                _mailService.SendGiftSubscr(model.Email);
                await _genericRepository.CreateAll(new List<object>() { subscr, userSubscr, });
                //TODO show success
                return View(new GiftViewModel { Authors = GetAuthors(), Genres = GetGenres(), SubscrTypes = GetTypes() });
            }
            return View(model);
        }

        private List<Type> GetTypes()
        {
            return _typeRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            return _authorRepository.GetAllAuthors().ToList();
        }

        private async Task<User?> GetUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private List<Genre> GetGenres()
        {
            return _genreRepository.Get().ToList();
        }
    }
}
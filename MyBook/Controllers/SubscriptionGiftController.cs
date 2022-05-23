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
        private readonly EFUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public SubscriptionGiftController(
            IGenericRepository<Type> typeRepository, EfAuthorRepository authorRepository,
          EFGenreRepository genreRepository, IGenericRepository<Object> genericRepository,
          UserManager<User> userManager, IMailService mailService, INotificationService notificationService, EFUserRepository userRepository)
        {
            _typeRepository = typeRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
            _genericRepository = genericRepository;
            _userManager = userManager;
            _mailService = mailService;
            _notificationService = notificationService;
            _userRepository = userRepository;
        }

        public IActionResult SubscriptionGift()
        {
            return View(new GiftViewModel { Authors = GetAuthors(), Genres = GetGenres(), SubscrTypes = GetTypes() });
        }

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
                var type = GetTypes().FirstOrDefault(it => it.TypeId == model.TypeId);
                var payModel = new PayViewModel
                {
                    UserId = user.Id,
                    Period = 1,
                    TypeId = type?.TypeId,
                    TypeName = type?.TypeName,
                    Price = type?.Price,
                    isGift = true
                };
                if (type?.TypeName == "Подписка на автора")
                {
                    if (model.AuthorName != null)
                    {
                        var author = _authorRepository.Get(it => it.Name == model.AuthorName).FirstOrDefault();
                        if (author == null)
                            return View(model);
                        payModel.SpecsId = author.AuthorId;
                        payModel.SpecsName = author.Name;

                        if (HasSubscr(typeId: (int)model.TypeId, userId: user.Id, authorId: author.AuthorId))
                        {
                            return RedirectToAction("SubscrExists", "Modals");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("AuthorName", "Укажите автора для подписки");
                        return View(model);
                    }
                }
                if (type?.TypeName == "Подписка на жанр")
                {
                    if (model.GenreName != null)
                    {
                        var genre = _genreRepository.Get(it => it.Name == model.GenreName).FirstOrDefault();
                        if (genre == null)
                            return View(model);
                        payModel.SpecsId = genre.GenreId;
                        payModel.SpecsName = genre.Name;
                        if (HasSubscr(typeId: (int)model.TypeId, userId: user.Id, genreId: genre.GenreId))
                        {
                            return RedirectToAction("SubscrExists", "Modals");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("GenreName", "Укажите жанр для подписки");
                        return View(model);
                    }
                }
                else if (type?.TypeName == "Премиум" && HasSubscr(typeId: (int)model.TypeId, userId: user.Id))
                {
                    return RedirectToAction("SubscrExists", "Modals");
                }
                return RedirectToAction("SubscriptionPay", "SubscriptionPay", payModel);
            }
            return View(model);
        }

        private bool HasSubscr(int typeId, string userId, int? genreId = null, int? authorId = null)
        {
            var user = _userRepository.GetUserWithSubscr(userId);
            if (user == null)
                return true;
            if (user.UserSubscrs == null || !(user.UserSubscrs.Any(it =>
                it.Subscription.TypeId == typeId &&
                ((genreId != null && it.Subscription.GenreId == genreId) || (authorId != null && it.Subscription.AuthorId == authorId) || it.Subscription.Type.TypeName == "Премиум"))))
                return false;
            else return true;
        }

        public async Task<IActionResult> PaySuccess(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
                var modalModel = new ModalsViewModel { ControllerName = "SubscriptionGift", ActionName = "SubscriptionGift" };
            if (user == null)
            {
                return RedirectToAction("Error", "Modals", modalModel);
            }
            _mailService.SendGiftSubscr(user.Email);
            await _notificationService.NotifyClient(id, "Подарок!", "Вам подарили подписку на наш сервис");
            return RedirectToAction("SubscriptionGift", "SubscriptionGift");
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
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Models;
using Repositories;

namespace MyBook.Controllers
{
    public class SubscriptionPayController : Controller
    {
        private readonly IGenericRepository<Object> _genericRepository;
        public SubscriptionPayController(IGenericRepository<Object> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IActionResult SubscriptionPay(PayViewModel model)
        {
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Pay(PayViewModel model)
        {
            var subscr = new Subscription
            {
                StartDate = DateTime.Now.ToString(),
                EndDate = DateTime.Now.AddMonths(model.Period).ToString(),
                TypeId = model.TypeId,
            };
            if (model.TypeName == "Подписка на автора")
                subscr.AuthorId = model.SpecsId;
            if (model.TypeName == "Подписка на жанр")
                subscr.GenreId = model.SpecsId;
            var userSubscr = new UserSubscr { Subscription = subscr, UserId = model.UserId };
            subscr.UserSubscr = userSubscr;
            await _genericRepository.CreateAll(new List<object>() { subscr, userSubscr, });
            //TODO show modal that subscr succesfully added
            if (model.isGift)
                return RedirectToAction("PaySuccess", "SubscriptionGift", new {userId=model.UserId});
            return RedirectToAction("Subscription", "Subscription");
        }
    }
}
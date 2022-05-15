using Microsoft.AspNetCore.Mvc;
using MyBook.Core.Interfaces;
using MyBook.Entities;
using MyBook.Models;
using Repositories;

namespace MyBook.Controllers
{
    public class SubscriptionPayController : Controller
    {
        private readonly IGenericRepository<Object> _genericRepository;
        private readonly IPaymentService _paymentService;
        public SubscriptionPayController(IGenericRepository<Object> genericRepository, IPaymentService paymentService)
        {
            _genericRepository = genericRepository;
            _paymentService = paymentService;
        }

        public IActionResult SubscriptionPay(PayViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Pay(PayViewModel model)
        {
            return View("PaymentModal", model);
        }


        [HttpPost]
        public async Task<IActionResult> PaymentModal(PayViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.CardNum) || string.IsNullOrWhiteSpace(model.CardCode) || string.IsNullOrWhiteSpace(model.CardDate) || string.IsNullOrWhiteSpace(model.CardName))
                {
                    ModelState.AddModelError("EmptyFields", "Заполните все поля");
                    return View(model);
                }
                if (!_paymentService.PerformPayment())
                {
                    ModelState.AddModelError("Unsuccessfull payment", "Оплата была отклонена");
                    return View(model);
                }
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
                    return RedirectToAction("PaySuccess", "SubscriptionGift", new { userId = model.UserId });
                return RedirectToAction("Subscription", "Subscription");
            }
            return View(model);
        }
    }
}
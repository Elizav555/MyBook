using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Infrastructure.Repositories;
using MyBook.Models;
using System.Text.RegularExpressions;

namespace MyBook.Controllers
{
    [Authorize(Policy = "ReadersOnly")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EFHistoryRepository _historyRepository;
        public UserProfileController(UserManager<User> userManager, SignInManager<User> signInManager, EFHistoryRepository historyRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _historyRepository = historyRepository;
        }

        public async Task<IActionResult> Index(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(new UserProfileViewModel { Id = id, BirthDate = DateTime.Parse(user.BirthDate), Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Histories = GetHistories(user.Id) });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    if (_userManager.Users.Any(userIdentity => userIdentity.Email == model.Email && userIdentity.UserName != user.UserName))
                    {
                        ModelState.AddModelError(string.Empty, "Пользователь с таким email уже существует");
                        return RedirectToAction("Index", new { model });
                    }
                    if (model.BirthDate == null)
                    {
                        ModelState.AddModelError(string.Empty, "Введите корректную дату рождения");
                        return RedirectToAction("Index", new { model });
                    }
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.BirthDate = model.BirthDate?.ToShortDateString();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", new { model });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPassword(EditPasswordViewModel model)
        {
            //TODO Почему то не отображается валидация
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", new { model.Id });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            if (error.Description == "Incorrect password.")
                                ModelState.AddModelError(string.Empty, "Введите верный старый пароль");
                            else ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return RedirectToAction("Index", new { model.Id });
        }

        public IActionResult NonSubscription()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private List<History> GetHistories(string userId)
        {
            return _historyRepository.GetHistories(userId).ToList();
        }
    }
}

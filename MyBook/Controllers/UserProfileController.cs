using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Models;
using MyBook.Models.UserProfile;
using System.Text.RegularExpressions;

namespace MyBook.Controllers
{
    [Authorize(Policy = "ReadersOnly")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserProfileController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index(string id)
        {
            return View(new UserProfileViewModel { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditProfileViewModel model = new EditProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = DateTime.Parse(user.BirthDate)
            };
            return PartialView("_EditProfile", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    if (_userManager.Users.Any(userIdentity => userIdentity.Email == model.Email && userIdentity.UserName != user.UserName))
                    {
                        ModelState.AddModelError(string.Empty, "Пользователь с таким email уже существует");
                        //return PartialView("_EditProfile", model);
                    }
                    if (model.BirthDate == null)
                    {
                        ModelState.AddModelError(string.Empty, "Введите корректную дату рождения");
                        //  return PartialView("_EditProfile", model);
                    }
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.BirthDate = model.BirthDate?.ToShortDateString();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
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
            // return PartialView("_EditProfile", model);
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
                        return RedirectToAction("EditProfile", new { model.Id });
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
            return RedirectToAction("EditProfile", new { model.Id });
        }

        public IActionResult EditSubscription(string id)
        {
            return PartialView("_EditSubscription", new EditUserSubscrViewModel { Id = id });
        }

        public IActionResult History(string id)
        {
            return PartialView("_History", new HistoryViewModel { Id = id });
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
    }
}

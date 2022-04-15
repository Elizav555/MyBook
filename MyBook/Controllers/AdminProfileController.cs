using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBook.Entities;
using MyBook.Models;
using MyBook.Models.Admin;
using Repositories;
using Type = MyBook.Entities.Type;
namespace MyBook.Controllers
{
    [Authorize(Policy = "AdminsOnly")]
    public class AdminProfileController : Controller
    {
        private readonly IGenericRepository<Type> _typeRepository;
        private readonly IGenericRepository<Author> _authorRepository;

        public AdminProfileController(IGenericRepository<Type> typeRep, IGenericRepository<Author> authorsRep)
        {
            _typeRepository = typeRep;
            _authorRepository = authorsRep;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditAuthor()
        {
            return PartialView("_EditAuthor", new EditAuthorViewModel { Authors = GetAuthors() });
        }

        public IActionResult EditBook()
        {
            return PartialView("_EditBook");
        }

        public IActionResult EditUser()
        {
            return PartialView("_EditUser");
        }

        public IActionResult EditBookCenter()
        {
            return PartialView("_EditBookCenter");
        }

        public IActionResult EditSubscription()
        {
            return PartialView("_EditSubscription", new EditSubscrViewModel { SubscrTypes = GetTypes() });
        }


        private List<Type> GetTypes()
        {
            return _typeRepository.Get().ToList();
        }

        private List<Author> GetAuthors()
        {
            return _authorRepository.Get().ToList();
        }
    }
}

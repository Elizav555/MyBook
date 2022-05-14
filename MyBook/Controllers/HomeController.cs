using Microsoft.AspNetCore.Mvc;
using MyBook.Models;
using System.Diagnostics;
using MyBook.Entities;
using Repositories;
using Microsoft.AspNetCore.SignalR;
using MyBook.Infrastructure.Hubs;
using MyBook.Core.Interfaces;
using System.Security.Claims;

namespace MyBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<BookCenter> _bookCenterRepository;

        public HomeController(IGenericRepository<BookCenter> bookCenterRepository)
        {
            _bookCenterRepository = bookCenterRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetBooksCenter()
        {
            var bookCenters = _bookCenterRepository.Get();
            return Json(bookCenters);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc;
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

        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly IHubContext<NotificationUserHub> _notificationUserHubContext;
        private readonly IUserConnectionManager _userConnectionManager;

        public HomeController(IGenericRepository<BookCenter> bookCenterRepository, IHubContext<NotificationHub> notificationHubContext, IHubContext<NotificationUserHub> notificationUserHubContext, IUserConnectionManager userConnectionManager)
        {
            _bookCenterRepository = bookCenterRepository;
            _notificationHubContext = notificationHubContext;
            _notificationUserHubContext = notificationUserHubContext;
            _userConnectionManager = userConnectionManager;
        }

        public async Task<IActionResult> Index()
        {
            //TODO generate notifications
            await _notificationHubContext.Clients.All.SendAsync("sendToUser", "Heading", "Content"); //send to all

            ////send to specific
            //var connections = _userConnectionManager.GetUserConnections(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //if (connections != null && connections.Count > 0)
            //{
            //    foreach (var connectionId in connections)
            //    {
            //        await _notificationUserHubContext.Clients.Client(connectionId).SendAsync("sendToUser", "Heading", "Content");
            //    }
            //}

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
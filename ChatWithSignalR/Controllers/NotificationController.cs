using SignalRSample.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace SignalRSample.Controllers
{
    public class NotificationController : Controller
    {
        private IHubContext<Notification> _hubContext;

        public NotificationController(IHubContext<Notification> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetNotificationsCount()
        {

            var randomValue = new Random().Next(100);

            // Invocation of cliente side monitoring and return a value 
            _hubContext.Clients.All.InvokeAsync("TotalOfNotifications", randomValue);

            return Ok();
        }
    }
}
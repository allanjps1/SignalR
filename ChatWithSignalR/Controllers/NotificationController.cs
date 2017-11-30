using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ChatWithSignalR.Hubs;

namespace ChatWithSignalR.Controllers
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
            // Invocation of cliente side monitoring and return a value 
            _hubContext.Clients.All.InvokeAsync("TotalOfNotifications", 5);

            return Ok();
        }
    }
}
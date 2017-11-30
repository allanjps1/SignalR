using Microsoft.AspNetCore.Mvc;

namespace ChatWithSignalR.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
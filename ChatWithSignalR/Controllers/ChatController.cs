using Microsoft.AspNetCore.Mvc;

namespace SignalRSample.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
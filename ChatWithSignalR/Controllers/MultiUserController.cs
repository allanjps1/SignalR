using Application.Services.Interface;
using Dominio.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SignalRSample.Controllers
{
    public class MultiUserController : Controller
    {
        IUserService _userService;

        public MultiUserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
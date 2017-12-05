using Application.Services.Interface;
using Dominio.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Chamado()
        {
            return View();
        }

        public IActionResult UsersQueue()
        {

            _userService.AddConectedUser(new User() { Nick = "teste1" });
            _userService.AddConectedUser(new User() { Nick = "teste2" });
            _userService.AddConectedUser(new User() { Nick = "teste3" });
            _userService.AddConectedUser(new User() { Nick = "teste4" });
            _userService.AddConectedUser(new User() { Nick = "teste5" });

            return View();
        }

        [HttpGet]
        public bool PossuiVagas()
        {
            if (_userService.GetUsersCount() < 5)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        public IActionResult AdicionarAFilaDeEspera()
        {
            _userService.AddUserToQueue(new User() { Nick = "Fulano de tal" });

            return Ok();
        }

        [HttpGet]
        public int PosicaoNaFila()
        {
            return _userService.UserQueuePosition(new User() { Nick = "Fulano de tal" });
        }
    }
}
using Application.Services.Interface;
using Dominio.Core.Models;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSample.Hubs
{
    public class MultiUserHub : Hub
    {
        IUserService _userService;

        public MultiUserHub(IUserService userService)
        {
            _userService = userService;
        }

        public override Task OnConnectedAsync()
        {
            User us = new User();
            us.ConnectionID = Context.ConnectionId;

            _userService.AddConectedUser(us);

            return base.OnConnectedAsync();
        }

        public async Task SendMessage(Mensagem mensagem)
        {
            await Clients.All.InvokeAsync("SendMessage", mensagem);
        }

        
    }
}

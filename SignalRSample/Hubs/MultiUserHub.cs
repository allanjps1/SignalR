using Application.Services.Interface;
using Dominio.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Models;
using System;
using System.Collections.Generic;
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
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(Mensagem mensagem, String clientId)
        {
            await Clients.Client(clientId).InvokeAsync("SendMessage", mensagem);
        }

        public async Task SendMessageChamado(Mensagem mensagem)
        {
            IReadOnlyList<string> lista = new List<String>() { Context.ConnectionId };

            await Clients.AllExcept(lista).InvokeAsync("SendMessageChamado", mensagem);
        }

        public async Task LogIn(User user)
        {
            user.ConnectionID = Context.ConnectionId;

            _userService.AddConectedUser(user);

            List<User> users = _userService.GetConnectedUsers();

            await Clients.All.InvokeAsync("UsersList", users);
        }

        public void AddConnectedUser()
        {
            User newuser = new User();
            newuser.ConnectionID = Context.ConnectionId;
            newuser.Nick = Context.Connection.User.Identity.Name;

            _userService.AddConectedUser(newuser);
        }

        public void DisconectUser(String connectionId)
        {
            _userService.RemoveConectedUser(connectionId);

            Context.Connection.Abort();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        
    }
}

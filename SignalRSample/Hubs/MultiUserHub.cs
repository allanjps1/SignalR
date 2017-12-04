using Application.Services.Interface;
using Dominio.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRSample.Hubs
{
    [Authorize]
    public class MultiUserHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

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


        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        
    }
}

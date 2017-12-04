using SignalRSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRSample.Hubs
{
    public class Chat : Hub
    {
        public void Mensagem(string apelido, string mensagem)
        {
            Clients.All.InvokeAsync("Mensagem", apelido, mensagem);
        }
        public async Task SendMessage(Mensagem mensagem)
        {
            await Clients.All.InvokeAsync("SendMessage", mensagem);
        }
    }
}

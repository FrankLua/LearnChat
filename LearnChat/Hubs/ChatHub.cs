using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LearnChat.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await SendMessage("", "UserConnected");
            await base.OnConnectedAsync();
        }
       public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("Message",userName, message);

        }
    }
}

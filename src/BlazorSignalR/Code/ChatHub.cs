using BlazorSignalR.Entities;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Code
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(ChatMessage chatMessage)
        {
            await Clients.All.SendAsync("ReceiveMessage", chatMessage);
        }
    }
}

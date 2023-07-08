using BlazorSignalR.Entities;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Code
{
    public class MousePositionTrackerHub : Hub
    {
        public async Task SendUserMousePosition(UserMousePosition userMousePosition)
        {
            await Clients.All.SendAsync("ReceiveUserMousePosition", userMousePosition);
        }

    }
}

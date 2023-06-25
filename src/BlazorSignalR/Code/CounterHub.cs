using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Code
{
    public class CounterHub : Hub
    {
        public async Task IncrementCount(int value)
        {
            await Clients.All.SendAsync("IncrementCount", value);
        }
    }
}

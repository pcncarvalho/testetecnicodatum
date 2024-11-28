using Microsoft.AspNetCore.SignalR;

namespace TestePraticoDATUM.Api.PushNotification
{
    public class PostNotificationHubSignalR : Hub
    {
        public async Task SendPost(string title, string description)
        {
            await Clients.All.SendAsync("ReceivePost", title, description);
        }
        public override async Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            await base.OnConnectedAsync();
        }
    }
}

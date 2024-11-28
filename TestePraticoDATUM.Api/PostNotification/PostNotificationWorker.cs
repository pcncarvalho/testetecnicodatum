using Microsoft.AspNetCore.SignalR;
using TestePraticoDATUM.Api.PushNotification;

namespace TestePraticoDATUM.Api.PostNotification
{
    public class PostNotificationWorker : BackgroundService
    {
        private readonly ILogger<PostNotificationWorker> _logger;
        private readonly IHubContext<PostNotificationHubSignalR> _postHub;

        public PostNotificationWorker(ILogger<PostNotificationWorker> logger, IHubContext<PostNotificationHubSignalR> postHub)
        {
            _logger = logger;
            _postHub = postHub;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    string title = "Nova vaga na DATUM";
                    var description = "Desenvolvedor .Net";
                    
                    //Send Notification
                    await _postHub.Clients.All.SendAsync("ReceivePost", title, description);

                    _logger.LogInformation("Sent post: {title} - {description}", title, description);

                    await Task.Delay(4000, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error sending post");
                }
            }
        }
    }
}
using Microsoft.AspNetCore.SignalR.Client;

namespace TestePraticoDATUM.Api.PostNotification
{
    public class ReceivePostNotification
    {
        public async Task<List<string>> ReceivePost()
        {
            string hubUrl = "https://localhost:7091/hubs/post";
            
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .Build();

            var messageList = new List<string>();

            hubConnection.On<string, decimal>("ReceivePost", (title, description) =>
            {
                messageList.Add($"Message received--> Post title: {title} Post description: {description}");
            });

            try
            {
                // Start connection SignalR
                hubConnection.StartAsync().Wait();
                messageList.Add("SignalR connection started.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error connecting to SignalR: {ex.Message}");
            }

            //Create a cancellation token to stop the connection
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            
            //hubConnection.StopAsync().Wait();
            var cancellationToken = cancellationTokenSource.Token;
            // Handle Ctrl+C to gracefully shut down the application
            
            Console.CancelKeyPress += (sender, a) =>
            {
                a.Cancel = true;
                Console.WriteLine("Stopping SignalR connection...");
                cancellationTokenSource.Cancel();
            };

            try
            {
                // Keep the application running until it is cancelled
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception(ex.Message);
            }

            await hubConnection.StopAsync();

            return messageList;
        }
    }
}

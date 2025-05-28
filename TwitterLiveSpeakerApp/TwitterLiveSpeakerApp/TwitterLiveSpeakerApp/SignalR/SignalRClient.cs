using Microsoft.AspNetCore.SignalR.Client;

namespace TwitterLiveSpeakerApp.SignalR
{
    public class SignalRClient
    {
        private HubConnection? _connection;

        public event Action<string>? OnLogReceived;
        public event Action<string, string, string>? OnAudioReceived;

        public async Task StartAsync(string url)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("ReceiveLog", message =>
            {
                OnLogReceived?.Invoke(message);
            });

            _connection.On<string, string, string>("ReceiveAudioData", (sender, message, audioBase64) =>
            {
                OnAudioReceived?.Invoke(sender, message, audioBase64);
            });

            await _connection.StartAsync();
        }

        public async Task StopAsync()
        {
            if (_connection != null)
                await _connection.StopAsync();
        }
    }
}
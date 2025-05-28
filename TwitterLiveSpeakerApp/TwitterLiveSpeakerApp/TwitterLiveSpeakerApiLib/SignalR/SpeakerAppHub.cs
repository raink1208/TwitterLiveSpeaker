using Microsoft.AspNetCore.SignalR;

namespace TwitterLiveSpeakerApiLib.SignalR
{
    public class SpeakerAppHub : Hub, ISpeakerAppHub
    {
        public async Task SendLog(string message)
        {
            await Clients.All.SendAsync("ReceiveLog", message);
        }

        public async Task SendAudioData(string sender, string message, string audioBase64)
        {
            await Clients.All.SendAsync("ReceiveAudioData", sender, message, audioBase64);
        }
    }
}
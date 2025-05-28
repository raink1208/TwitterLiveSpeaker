using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TwitterLiveSpeakerApiLib.SignalR
{
    public interface ISpeakerAppHub
    {
        public Task SendLog(string message);
        public Task SendAudioData(string sender, string message, string audioBase64);
    }
}
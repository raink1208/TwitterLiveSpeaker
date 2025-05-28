using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLiveSpeakerApp.Settings
{
    public class SpeakerAppSettings
    {
        public required SpeakerApiSetting SpeakerApiSetting { get; set; }
        public required VoiceBoxSetting VoiceBoxSetting { get; set; }
    }

    public class SpeakerApiSetting
    {
        public required int Port { get; set; }
        public required string SignalREndpoint { get; set; }
    }

    public class VoiceBoxSetting
    {
        public required string ApiUrl { get; set; }
        public required string SpeakerUUID { get; set; }
        public required string SpeakerID { get; set; }
        public required float Speed { get; set; }
        public required float Pitch { get; set; }
        public required float Volume { get; set; }
    }
}
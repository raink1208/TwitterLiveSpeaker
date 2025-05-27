using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterLiveSpeakerApiLib.Infrastructure.VoiceBox;
using TwitterLiveSpeakerApiLib.Models;

namespace TwitterLiveSpeakerApiLib.Services
{
    public class SpeakerService
    {
        private VoiceBoxClient _voiceBoxClient;

        private Speaker? _currentSpeaker;
        private SpeakerStyle? _currentSpeakerStyle;

        public SpeakerService(VoiceBoxClient voiceBoxClient)
        {
            _voiceBoxClient = voiceBoxClient;
        }

        public async Task<List<Speaker>> GetSpeakerList()
        {
            return await _voiceBoxClient.GetSpeakerList();
        }
    }
}
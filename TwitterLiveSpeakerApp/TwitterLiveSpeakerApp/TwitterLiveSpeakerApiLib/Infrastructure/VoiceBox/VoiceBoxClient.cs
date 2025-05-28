using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterLiveSpeakerApiLib.Models;

namespace TwitterLiveSpeakerApiLib.Infrastructure.VoiceBox
{
    public class VoiceBoxClient
    {
        private HttpClient _httpClient;
        public VoiceBoxClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Speaker>> GetSpeakerList()
        {
            var result = await _httpClient.GetAsync("");
            return null;

        }
    }
}
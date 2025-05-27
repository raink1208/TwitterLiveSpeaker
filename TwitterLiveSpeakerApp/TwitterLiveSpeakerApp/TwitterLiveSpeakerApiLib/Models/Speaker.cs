using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLiveSpeakerApiLib.Models
{
    public class Speaker
    {
        public required string Name { get; set; }
        public required string SpeakerUuid { get; set; }
        public List<SpeakerStyle> Styles { get; set; } = new List<SpeakerStyle>();
        public required string Version { get; set; }
        public SpeakerSupportedFeatures? SpeakerSupportedFeatures { get; set; }
    }

    public class SpeakerStyle
    {
        public required string Name { get; set; }
        public required int Id { get; set; }
        public required string Type { get; set; }
    }

    public class SpeakerSupportedFeatures
    {
        public string? PermittedSynthesisMorphing { get; set; }
    }
}
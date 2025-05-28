using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterLiveSpeakerApiLib.Services;

namespace TwitterLiveSpeakerApiLib.Controllers
{
    [ApiController]
    [Route("api/settings")]
    public class SettingController : ControllerBase
    {
        private SpeakerService _speakerService;

        public SettingController(SpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("speakers")]
        public async Task<IActionResult> GetSpeakerList()
        {
            return Ok();
        }

        [HttpGet("speaker")]
        public async Task<IActionResult> GetSpeaker()
        {
            return Ok();
        }

        [HttpPost("speaker")]
        public async Task<IActionResult> SetSpeaker()
        {
            return Ok();
        }
    }
}
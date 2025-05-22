using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLiveSpeakerApiLib.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class LiveChatController: ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostChat([FromBody]ChatRequest request)
        {
            Console.WriteLine($"Received chat: {request.Chat}");
            return Ok("Chat received successfully");
        }
    }

    public class ChatRequest
    {
        public required string Chat { get; set; }
    }
}

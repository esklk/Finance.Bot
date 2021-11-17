using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace Finance.Bot.Web.Controllers
{
    public class WebhookController : ControllerBase
    {
        [HttpPost]
        public IActionResult OnUpdate([FromBody]Update update)
        {
            return Ok("Hello world!");
        }
    }
}

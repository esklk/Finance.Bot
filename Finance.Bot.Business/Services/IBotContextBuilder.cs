using Finance.Bot.Business.Services.Implementation;
using Telegram.Bot.Types;

namespace Finance.Bot.Business.Services
{
    interface IBotContextBuilder
    {
        BotContext Build(Update update);
    }
}

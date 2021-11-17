using Telegram.Bot.Types;

namespace Finance.Bot.Business.Services
{
    public interface IBotStateFactory
    {
        IBotState Create(Update update);
    }
}

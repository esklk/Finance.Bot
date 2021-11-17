using Finance.Bot.Business.Services.Implementation;
using System.Threading.Tasks;

namespace Finance.Bot.Business.Services
{
    public interface IBotState
    {
        Task HandleAsync(BotContext context);
    }
}

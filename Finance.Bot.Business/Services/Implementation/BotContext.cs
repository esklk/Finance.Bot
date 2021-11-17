using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Finance.Bot.Business.Services.Implementation
{
    public class BotContext
    {
        public BotContext(IBotState initialState, Update update)
        {
            CurrentState = initialState ?? throw new ArgumentNullException(nameof(initialState));
            Update = update ?? throw new ArgumentNullException(nameof(update));
        }

        public IBotState CurrentState { get; set; }

        public Update Update { get; set; }

        public async Task ProcessAsync()
        {
            await CurrentState.HandleAsync(this);
        }
    }
}

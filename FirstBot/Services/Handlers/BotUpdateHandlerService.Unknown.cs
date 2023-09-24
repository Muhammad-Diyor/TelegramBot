using Telegram.Bot.Types;
using Telegram.Bot;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task HandleUnknownUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
    {
        await client.SendTextMessageAsync(update.Message.From.Id, update.Type.ToString());
    }
}

using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task HandleMessageAsync(TelegramBotClient client, Message? message, CancellationToken token)
    {
        await client.SendTextMessageAsync(message.From.Id, "Hello");
    }
}

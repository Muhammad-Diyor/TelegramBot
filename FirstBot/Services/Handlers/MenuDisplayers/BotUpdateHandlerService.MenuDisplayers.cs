using FirstBot.Helpers;
using FirstBot.Menu;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task DisplayMainMenuAsync(ITelegramBotClient client, Message message, CancellationToken token)
    {
        await client.SendTextMessageAsync(
            message.Chat.Id, localizer["start"],
            replyMarkup: MarkupHelpers.GetInlineKeyboardMatrix(
                MenuDictionary.MainMenu),
            cancellationToken: token);
    }
}

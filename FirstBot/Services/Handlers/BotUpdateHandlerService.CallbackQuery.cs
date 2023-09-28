using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task HandleCallbackQueryAsync(ITelegramBotClient client, CallbackQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query);

        var from = query.From;

        var handler = query.Data switch
        {
            "Add-book" => AddBookQuery(client, query, cancellationToken),

            _ => AddBookQuery(client, query, cancellationToken)
        };

        await handler;
    }

    private async Task AddBookQuery(ITelegramBotClient client, CallbackQuery query,
        CancellationToken cancellationToken)
    {
        client.SendTextMessageAsync(query.Message.Chat.Id, "Nima gap");
    }

    private async Task GetBooksQuery(ITelegramBotClient client, CallbackQuery query,
        CancellationToken cancellationToken)
    {
        Console.WriteLine("Eh");
    }
}

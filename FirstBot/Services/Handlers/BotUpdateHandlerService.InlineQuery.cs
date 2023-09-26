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

        Log.Information($"Got a callback query from {query.From.FirstName} \n Query is {query.Message}");
        var handler = query.Data switch
        {
            "Hello" => GetBooksQuery(client, query, cancellationToken),

            _ => GetBooksQuery(client, query, cancellationToken)
        };

        await handler;
    }

    private async Task GetBooksQuery(ITelegramBotClient client, CallbackQuery query,
        CancellationToken cancellationToken)
    {
        Console.WriteLine("Eh");
    }
}

using Serilog;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Requests;
using FirstBot.Services.NonHandlerServices;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
    {
        var scope = scopeFactory.CreateScope();

        usersService = scope.ServiceProvider.GetRequiredService<UserService>();

        if (message.Text.ToLower() == "/start")
            await HandleStartAsync(client, message, cancellationToken);
        else
        {
            await client.SendTextMessageAsync(message.From.Id, "Notanish buyruq, boshqa buyruqni tanlang", cancellationToken:cancellationToken);
        }
    }

    private async Task HandleStartAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var from = message.From;
        var userExists = usersService.UserExists(from.Id).Data;

        if (!userExists)
        {
            await usersService.AddUser(message.From);
            await DisplayMainMenuAsync(client, message, cancellationToken);
        }
        else
        {
            await DisplayMainMenuAsync(client, message, cancellationToken);
        }

    }
}

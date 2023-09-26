using FirstBot.Helpers;
using Serilog;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
    {
        var scope = scopeFactory.CreateScope();

        usersService = scope.ServiceProvider.GetRequiredService<UserService>();

        if (message.Text.ToLower() == "/start")
            HandleStartAsync(client, message, cancellationToken);
        else if (message.Text == "inline")
            Log.Information("Hi");
        else
        {
            var users = usersService.GetUsers();
            await client.SendTextMessageAsync(message.From.Id, "hi");
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

using Telegram.Bot.Types;
using Telegram.Bot;
namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken token)
    {
        var scope = scopeFactory.CreateScope();

        usersService = scope.ServiceProvider.GetRequiredService<UserService>();

        if(message.Text == "start")
            usersService.AddUser(message.From);
        else
        {
            var users = usersService.GetUsers();
            await client.SendTextMessageAsync(message.From.Id, users.Data.First().FirstName);
        }
    }
}

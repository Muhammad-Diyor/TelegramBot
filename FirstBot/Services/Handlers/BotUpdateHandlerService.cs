using Microsoft.VisualBasic;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandlerService> logger;

    public BotUpdateHandlerService(ILogger<BotUpdateHandlerService> logger)
    {
        this.logger = logger;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        //if(update.Type == UpdateType.Message)
        //    await HandleMessageAsync(botClient, update, cancellationToken);

        Console.WriteLine("update.Message");
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}

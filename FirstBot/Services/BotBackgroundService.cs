using Telegram.Bot;
using Telegram.Bot.Polling;

namespace FirstBot.Services;

public class BotBackgroundService : BackgroundService
{
    private ILogger<BotBackgroundService> logger;
    private TelegramBotClient botClient;
    private IUpdateHandler handler;
    public BotBackgroundService(ILogger<BotBackgroundService> logger, TelegramBotClient botClient, IUpdateHandler handler)
    {
        this.logger = logger;
        this.botClient = botClient;
        this.handler = handler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await botClient.GetMeAsync(stoppingToken);
        logger.LogInformation($"Bot started successfully: {bot.Username}");

        botClient.StartReceiving(handler.HandleUpdateAsync, 
            handler.HandlePollingErrorAsync,
            new ReceiverOptions()
        {
            ThrowPendingUpdates = true,
        }, stoppingToken);
    }
}

using System.Globalization;
using FirstBot.Resources;
using Microsoft.Extensions.Localization;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace FirstBot.Services.Handlers;

public partial class BotUpdateHandlerService : IUpdateHandler
{
    private readonly ILogger<BotUpdateHandlerService> logger;
    private readonly IServiceScopeFactory scopeFactory;
    private IStringLocalizer localizer;
    private UserService usersService;
    public BotUpdateHandlerService(ILogger<BotUpdateHandlerService> logger, IServiceScopeFactory scopeFactory, IStringLocalizer localizer)
    {
        this.logger = logger;
        this.scopeFactory = scopeFactory;
        this.localizer = localizer;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {   
            var culture = new CultureInfo("en-En");

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            var scope = scopeFactory.CreateScope();
            
            localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<BotLocalizer>>();
            usersService = scope.ServiceProvider.GetRequiredService<UserService>();

            var handler = update.Type switch
            {
                UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                _ => HandleUnknownUpdateAsync(botClient, update, cancellationToken)
            };

            Console.WriteLine(nameof(handler) + " aaaaaaa");

            try
            {
                await handler;
            }
            catch (Exception e)
            {
                botClient.SendTextMessageAsync(update.Message.From.Id, e.Message + "\n" + e.InnerException);
                await HandlePollingErrorAsync(botClient, e, cancellationToken);
            }
        }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception.Message);

        return Task.CompletedTask;
    }

}

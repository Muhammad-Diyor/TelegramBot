﻿using System.Globalization;
using FirstBot.Helpers;
using FirstBot.Resources;
using FirstBot.Services.NonHandlerServices;
using Microsoft.Extensions.Localization;
using Serilog;
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
        InjectServices();

        var handler = update.Type switch
        {
            UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
            UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update.CallbackQuery!, cancellationToken),
            _ => HandleUnknownUpdateAsync(botClient, update, cancellationToken)
        };

        TLogger.LogError("Just setting up logger", "Ignore me");

        try
        {
            await handler;
            
        }
        catch (Exception e)
        {
            TLogger.LogError(e.Message, e.InnerException.Message );
            await HandlePollingErrorAsync(botClient, e, cancellationToken);
        }
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception.Message);

        return Task.CompletedTask;
    }

    private void InjectServices()
    {
        var scope = scopeFactory.CreateScope();

        localizer = scope.ServiceProvider.GetRequiredService<IStringLocalizer<BotLocalizer>>();
        usersService = scope.ServiceProvider.GetRequiredService<UserService>();
    }
}

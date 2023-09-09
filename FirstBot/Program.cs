using FirstBot.Services;
using FirstBot.Services.Handlers;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotToken", String.Empty);

builder.Services.AddSingleton(new TelegramBotClient(token!));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandlerService>();
builder.Services.AddHostedService<BotBackgroundService>();

var app = builder.Build();

app.Run();

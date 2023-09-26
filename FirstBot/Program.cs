using FirstBot.Data;
using FirstBot.Repositories;
using FirstBot.Resources;
using FirstBot.Services;
using FirstBot.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);

var token = builder.Configuration.GetValue("BotToken", String.Empty);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))); 

builder.Services.AddSingleton(new TelegramBotClient(token!));
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandlerService>();
builder.Services.AddSingleton<IStringLocalizer, StringLocalizer<BotLocalizer>>();
builder.Services.AddHostedService<BotBackgroundService>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UsersRepository>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.TeleSink("5843621363:AAFiycHoNHeFGUzGmKrczcOWJCd1b82hWJo", "-1001651963754", minimumLevel: Serilog.Events.LogEventLevel.Information)
    .CreateLogger();

builder.Services.AddLocalization();

var app = builder.Build();

var supportedCultures = new[] { "uz-Uz", "en-Us" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.Run();

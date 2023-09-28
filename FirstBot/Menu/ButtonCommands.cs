using Telegram.Bot.Types;
using TelegramSink.TelegramBotClient;

namespace FirstBot.Menu;

public static class ButtonCommands
{
    public static List<BotCommand> StartCommands { get; set; } = new List<BotCommand>
    {
        new BotCommand()
        {
            Command = "Yangi kitob qo'shish",
            Description = "Salom"
        }
    };
}

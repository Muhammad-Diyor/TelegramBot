using Serilog;

namespace FirstBot.Helpers;


// TLogger - Telegram Logger
// I use this class to log errors in telegram in a better style
public static class TLogger
{
    public static void LogError(string errorMessage, string innerException)
    {
        var callingMethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;

        string template =
            $"⚠️ Error\r\n\r\n📄 Exception: {errorMessage}\r\n📑 InnerException: {innerException}\r\n⚙️ Method: {callingMethod}";

        Log.Error(template);
    }

    public static void LogInformation(string info)
    {
        var callingMethod = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;

        string template =
            $"📄 Info: {info}";  

        Log.Information(template);
    }
}

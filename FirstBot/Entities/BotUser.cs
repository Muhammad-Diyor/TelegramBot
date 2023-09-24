namespace FirstBot.Entities;

public class BotUser
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Username { get; set; }
    public string LanguageCode { get; set; }
}

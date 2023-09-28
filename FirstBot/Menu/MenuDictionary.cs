namespace FirstBot.Menu;

public static class MenuDictionary
{
    public static Dictionary<string, string> MainMenu => new()
    {
        {"Add-book", "Kitob qo'shish"},
        {"Get-book", "Kitob olish"}
    };
}
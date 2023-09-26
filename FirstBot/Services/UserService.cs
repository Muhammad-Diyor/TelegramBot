using FirstBot.Entities;
using FirstBot.Models;
using FirstBot.Repositories;
using Telegram.Bot.Types;

namespace FirstBot.Services;

public class UserService
{
    private UsersRepository usersRepository;
    private readonly IServiceScopeFactory _scopeFactory;

    public UserService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Result<IEnumerable<BotUser>> GetUsers()
    {
        InjectServices();
        return usersRepository.GetUsers();
    }

    public async Task<Result<string>> AddUser(User user)
    {
        InjectServices();
        return await usersRepository.AddUserAsync(user);
    }

    public Result<bool> UserExists(long Id)
    {
        InjectServices();
        return usersRepository.UserExists(Id);
    }

    private void InjectServices()
    {
        var scope = _scopeFactory.CreateScope();
        usersRepository = scope.ServiceProvider.GetRequiredService<UsersRepository>();
    }
}

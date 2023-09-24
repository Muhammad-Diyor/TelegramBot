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
        var scope = _scopeFactory.CreateScope();
        usersRepository = scope.ServiceProvider.GetRequiredService<UsersRepository>();

        return usersRepository.GetUsers();
    }

    public async Task<Result<string>> AddUser(User user)
    {
        var scope = _scopeFactory.CreateScope();
        usersRepository = scope.ServiceProvider.GetRequiredService<UsersRepository>();

        return await usersRepository.AddUserAsync(user);
    }
}

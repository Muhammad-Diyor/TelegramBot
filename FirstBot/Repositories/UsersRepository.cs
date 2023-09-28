using FirstBot.Data;
using FirstBot.Entities;
using FirstBot.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;

namespace FirstBot.Repositories;

public class UsersRepository
{
    private AppDbContext context;
    private readonly IServiceScopeFactory scopeFactory;

    public UsersRepository(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    public async Task<Result<string>> AddUserAsync(User user)
    {
        var scope = scopeFactory.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        var botUser = user.Adapt<BotUser>();
        botUser.JoinedAt = DateTime.Now;
        try
        {
            await context.Users.AddAsync(botUser);
            await context.SaveChangesAsync();
            return new Result<string>() { Success = true };
        }
        catch (Exception e)
        {
            return new Result<string>() {Message = e.Message};
        }
    }

    public Result<IEnumerable<BotUser>> GetUsers()
    {
        var scope = scopeFactory.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            var users = context.Users.AsEnumerable();

            return new Result<IEnumerable<BotUser>>() { Success = true, Data = users };
        }
        catch (Exception e)
        {
            return new Result<IEnumerable<BotUser>>() { Message = e.Message };
        }
    }

    public Result<bool> UserExists(long Id)
    {
        var scope = scopeFactory.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            var exists = context.Users.Any(u => u.Id == Id);
            return new Result<bool>() { Success = true, Data = true};
        }
        catch (Exception e)
        {
            return new Result<bool>(){Message = e.Message};
        }
    }

    public async Task<Result<bool>> SetUserStepAsync(long userId, UserStep step)
    {
        var scope = scopeFactory.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return new Result<bool>() { Success = true, Data = true };
        }
        catch (Exception e)
        {
            return new Result<bool>() { Message = e.Message };
        }
    }
}

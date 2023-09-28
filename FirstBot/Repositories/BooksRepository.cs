using FirstBot.Data;
using FirstBot.Entities;
using FirstBot.Models;
using Mapster;
using Telegram.Bot.Types;

namespace FirstBot.Repositories;

public class BooksRepository
{
    private AppDbContext? context;
    private readonly IServiceScopeFactory scopeFactory;

    public BooksRepository(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    public async Task<Result<string>> AddBookAsync(Book book)
    {
        var scope = scopeFactory.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return new Result<string>() { Success = true };
        }
        catch (Exception e)
        {
            return new Result<string>() { Message = e.Message };
        }
    }

    public Result<IEnumerable<Book>> GetBooks()
    {
        var scope = scopeFactory.CreateScope();
        context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            var books = context.Books.AsEnumerable();

            return new Result<IEnumerable<Book>>() { Success = true, Data = books };
        }
        catch (Exception e)
        {
            return new Result<IEnumerable<Book>>() { Message = e.Message };
        }
    }
}

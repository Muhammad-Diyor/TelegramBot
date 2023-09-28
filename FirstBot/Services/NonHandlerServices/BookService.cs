using FirstBot.Entities;
using FirstBot.Models;
using FirstBot.Repositories;
using Telegram.Bot.Types;

namespace FirstBot.Services.NonHandlerServices;

public class BookService
{
    private BooksRepository booksRepository;
    private readonly IServiceScopeFactory _scopeFactory;

    public BookService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public Result<IEnumerable<Book>> GetBooks()
    {
        InjectServices();
        return booksRepository.GetBooks();
    }

    public async Task<Result<string>> AddBook(Book book)
    {
        InjectServices();
        return await booksRepository.AddBookAsync(book);
    }

    private void InjectServices()
    {
        var scope = _scopeFactory.CreateScope();
        booksRepository = scope.ServiceProvider.GetRequiredService<BooksRepository>();
    }
}

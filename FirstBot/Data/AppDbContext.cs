using FirstBot.Entities;
using Microsoft.EntityFrameworkCore;
namespace FirstBot.Data;

public class AppDbContext : DbContext
{
    public DbSet<BotUser>? Users { get; set; }
    public DbSet<Book>? Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}

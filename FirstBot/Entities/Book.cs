namespace FirstBot.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Author { get; set; }
    public long OwnerId { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}

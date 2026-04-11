namespace RocketBooks.Entities;

public class Book
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public enum BookGenre
{
    Fiction,
    NonFiction,
    ScienceFiction,
    Fantasy,
    Mystery,
    Biography,
    History,
    Romance,
    Thriller
}
using RocketBooks.Entities;

namespace RocketBooks.Communication.Requests;

public class RequestRegisterBook
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

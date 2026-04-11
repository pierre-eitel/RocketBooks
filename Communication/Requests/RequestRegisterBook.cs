using RocketBooks.Entities;
using System.ComponentModel.DataAnnotations;

public class RequestRegisterBook
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(2)]
    [MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Author is required")]
    [MinLength(2)]
    [MaxLength(120)]
    public string Author { get; set; } = string.Empty;

    [Required]
    public BookGenre Genre { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
    public int Stock { get; set; }
}
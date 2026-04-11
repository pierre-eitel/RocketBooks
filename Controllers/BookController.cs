using Microsoft.AspNetCore.Mvc;
using RocketBooks.Communication.Requests;
using RocketBooks.Entities;

namespace RocketBooks;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> _books = new List<Book>();

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBookById([FromRoute] Guid id)
    {
        var exits = _books.Any(x => x.Id == id);

        if (exits)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);

            return Ok(book);
        } else
        {
            return NotFound("Livro não encontrado");
        }        
    }

    [HttpPost]
    [ProducesResponseType(typeof(RequestRegisterBook), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterBook request)
    {
        var exists = _books
            .Any(b => b.Title == request.Title && b.Author == request.Author);

        if (exists)
        {
            return Conflict("Já existe um livro com esse título e autor");
        }

        if (request.Price <= 0)
        {
            return BadRequest("O preço deve ser maior que zero");
        } else if (request.Stock < 0) {
            return BadRequest("O estoque não pode ser negativo");
        }

        if (!Enum.TryParse<BookGenre>(request.Genre.ToString(), true, out _))
        {
            return BadRequest("Gênero inválido");
        }

        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow
        };

        _books.Add(book);

        return Created(string.Empty, book);
    }
}

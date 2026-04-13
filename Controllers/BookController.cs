using Microsoft.AspNetCore.Mvc;
using RocketBooks.Communication.Requests;
using RocketBooks.Entities;

namespace RocketBooks;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly static List<Book> _books = [];

    [HttpPost]
    [ProducesResponseType(typeof(RequestRegisterBook), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterBook request)
    {
        var exists = _books
            .Any(b => b.Title == request.Title && b.Author == request.Author);

        if (exists)
        {
            return Conflict("There is already a book with that title and author.");
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

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(_books);
    }

   [HttpPut]
   [Route("{id}")]
   [ProducesResponseType(typeof(RequestRegisterBook), StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestRegisterBook request)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);

        if (book == null)
        {
            return NotFound("Livro não encontrado");
        }

        book.Title = request.Title;
        book.Author = request.Author;
        book.Genre = request.Genre;
        book.Price = request.Price;
        book.Stock = request.Stock;

        return Ok(book);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var book = _books.FirstOrDefault(x => x.Id == id);
        if (book == null)
        {
            return NotFound("Livro não encontrado");
        }
        _books.Remove(book);

        return NoContent();
    }
}
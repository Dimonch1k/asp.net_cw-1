using asp.net_cw_1._2.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace asp.net_cw_1._2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        private static List<Book> books = new List<Book>
        {
            new Book{ Id = 1, Title = "Title1", Author = "Author1", Price = 100},
            new Book{ Id = 2, Title = "Title2", Author = "Author2", Price = 200},
            new Book{ Id = 3, Title = "Title3", Author = "Author3", Price = 300},
        };

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            Book? book = books.FirstOrDefault(b => b.Id == id);

            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPut("create")]
        public ActionResult<Book> Create([FromBody] Book newBook)
        {
            if (newBook == null) return BadRequest("Book is empty");

            newBook.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

        [HttpPatch("changeTitleById/{id}")]
        public ActionResult ChangeTitle(int id, [FromBody] UpdateTitleDto updateTitleDto)
        {
            if (string.IsNullOrEmpty(updateTitleDto.Title)) return BadRequest("Title is missing. This request changes only the title field.");
            Book? book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound("The book is missing in the library. Please enter a correct ID.");

            book.Title = updateTitleDto.Title;

            return NoContent();
        }

        [HttpPatch("changeAuthorById/{id}")]
        public ActionResult ChangeAuthor(int id, [FromBody] UpdateAuthorDto updateAuthorDto)
        {
            if (string.IsNullOrEmpty(updateAuthorDto.Author)) return BadRequest("Author is missing. This request changes only the author field.");
            Book? book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound("The book is missing in the library. Please enter a correct ID.");

            book.Author = updateAuthorDto.Author;

            return NoContent();
        }

        [HttpDelete("deleteById/{id}")]
        public ActionResult DeleteBook(int id)
        {
            Book? book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound("The book is missing in the library. Please enter a correct ID to delete.");

            books.Remove(book);
            return NoContent();
        }
    }
}

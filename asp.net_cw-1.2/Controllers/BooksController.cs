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
    }
}

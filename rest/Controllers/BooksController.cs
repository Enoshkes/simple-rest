using Microsoft.AspNetCore.Mvc;
using rest.Models;

namespace rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> _books = [
            new () { Title = "1948", ISBN = "horror", Id = 1 },
            new () { Title = "Harry Potter", ISBN = "SCIFI" , Id = 2 },
            new () { Title = "Someone to run with", ISBN = "children", Id = 3 },
        ];

        [HttpGet]
        public ActionResult<List<Book>> GetAll() => Ok(_books);

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book book)
        {
            book.Id = _books.Max(x => x.Id) + 1;
            _books.Add(book);
            return CreatedAtAction(nameof(Get), new { id =  book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Update(int id, [FromBody] Book book)
        {
            var bookToUpdate = _books.FirstOrDefault(x => x.Id == id);
            if (bookToUpdate== null) { return NotFound(); }
            bookToUpdate.Title = book.Title;
            bookToUpdate.ISBN = book.ISBN;
            return Ok(bookToUpdate);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bookToDelete = _books.FirstOrDefault(x =>x.Id == id);
            if (bookToDelete== null) {  return  NotFound(); }
            _books.Remove(bookToDelete);
            return Ok(bookToDelete);
        }
    }
}
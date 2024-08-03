using Microsoft.AspNetCore.Mvc;
using rest.Models;
using rest.Service;

namespace rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        private readonly IBookService _bookService = bookService;

        [HttpGet("Seed")]
        public ActionResult Seed()
        {
            _bookService.Seed();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll() => 
            Ok(await _bookService.GetBooksAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody] Book book)
        {   
            var addedBook = await _bookService.CreateBookAsync(book);
            return CreatedAtAction(nameof(Get), new { id =  addedBook.Id }, addedBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Update(int id, [FromBody] Book book)
        {
            try
            {
                var updated = await _bookService.UpdateBookAsync(id, book);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var deletedBook = await _bookService.DeleteBookAsync(id);
                return Ok(deletedBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
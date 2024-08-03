using Microsoft.EntityFrameworkCore;
using rest.Data;
using rest.Models;

namespace rest.Service
{
    public class BookService(ApplicationDbContext context) : IBookService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Book> CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBookAsync(int id)
        {
            var bookToDelete = await GetBookByIdAsync(id)
                ?? throw new Exception($"Book by the id {id} does not exists");
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return bookToDelete;
        }

        public async Task<Book?> GetBookByIdAsync(int id) =>
            await _context.Books.FindAsync(id);

        public async Task<IEnumerable<Book>> GetBooksAsync() =>
            await _context.Books.ToListAsync();

        public void Seed()
        {
            if (!_context.Books.Any())
            {
                IEnumerable<Book> _books = [
                    new () { Title = "1948", ISBN = "horror" },
                    new () { Title = "Harry Potter", ISBN = "SCIFI" },
                    new () { Title = "Someone to run with", ISBN = "children" },
                ];

                _context.Books.AddRange(_books);
                _context.SaveChanges();
            }
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            var bookToUpdate = await GetBookByIdAsync(id) 
                    ?? throw new Exception($"Book by the id {id} does not exists");
            bookToUpdate.Title = book.Title;
            bookToUpdate.ISBN = book.ISBN;
            await _context.SaveChangesAsync();
            return bookToUpdate;
        }
    }
}

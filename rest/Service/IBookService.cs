using rest.Models;

namespace rest.Service
{
    public interface IBookService
    {
        void Seed();
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);  
        Task<Book> UpdateBookAsync(int id, Book book);
        Task<Book> DeleteBookAsync(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using rest.Data;
using rest.Models;

namespace rest.Service
{
    public class ProductService(ApplicationDbContext context) : IProductService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Product>> GetInRangeAsync(double? min, double? max) =>
            await _context.Products.Where(p =>
                    (!min.HasValue || p.Price >= min.Value) &&
                    (!max.HasValue || p.Price <= max.Value))
                .ToListAsync();

        public void Seed()
        {
            if (!_context.Products.Any())
            {
                IEnumerable<Product> _products = [
                    new () { Name = "Laptop", Price = 1999.9},
                    new () { Name = "IPhone", Price = 3000.99},
                    new () { Name = "Headphones", Price = 299.90},
                ];
                _context.Products.AddRange(_products);
                _context.SaveChanges();
            }
        }
    }
}

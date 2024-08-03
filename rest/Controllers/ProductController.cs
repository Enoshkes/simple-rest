using Microsoft.AspNetCore.Mvc;
using rest.Models;

namespace rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private static readonly List<Product> _products = [
            new () { Name = "Laptop", Price = 1999.9, Id = 1},
            new () { Name = "IPhone", Price = 3000.99, Id = 2},
            new () { Name = "Headphones", Price = 299.90, Id = 3},
        ];

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts(
            [FromQuery] double? minPrice,
            [FromQuery] double? maxPrice
        )
        {
            var filteredProducts = _products
                .Where(p => 
                    (!minPrice.HasValue || p.Price >= minPrice.Value) &&
                    (!maxPrice.HasValue || p.Price <= maxPrice.Value))
                .ToList();

            var response = new
            {
                TotalCount = filteredProducts.Count,
                Products = filteredProducts
            };

            return Ok(response);
        }
    }
}

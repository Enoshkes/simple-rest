using Microsoft.AspNetCore.Mvc;
using rest.Models;
using rest.Service;

namespace rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : Controller
    {
        private readonly IProductService _productService = productService;

        [HttpGet("Seed")]
        public IActionResult Seed()
        {
            _productService.Seed();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] double? minPrice,
            [FromQuery] double? maxPrice
        )
        {
            var filteredProducts = await _productService.GetInRangeAsync(minPrice, maxPrice);

            var response = new
            {
                TotalCount = filteredProducts.Count,
                Products = filteredProducts
            };

            return Ok(response);
        }
    }
}

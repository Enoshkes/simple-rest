using rest.Models;

namespace rest.Service
{
    public interface IProductService
    {
        void Seed();
        Task<List<Product>> GetInRangeAsync(double? min, double? max);  
    }
}

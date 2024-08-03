using Microsoft.EntityFrameworkCore;
using rest.Models;
using rest.Service;

namespace rest.Data
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IConfiguration configuration
        ) : DbContext(options)
    {
        private readonly IConfiguration _configuration = configuration;

        public DbSet<Book> Books { get; private set; }
        public DbSet<Product> Products { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}

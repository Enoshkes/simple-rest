using System.ComponentModel.DataAnnotations;

namespace rest.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public required double Price { get; set; }
    }
}
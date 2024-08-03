using System.ComponentModel.DataAnnotations;

namespace rest.Models
{
    public class Book
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [StringLength(13)]
        public required string ISBN { get; set; }



    }
}

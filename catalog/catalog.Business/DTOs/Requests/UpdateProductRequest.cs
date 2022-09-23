using System.ComponentModel.DataAnnotations;

namespace catalog.Business.DTOs.Requests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }
        public int CategoryId { get; set; }
    }
}

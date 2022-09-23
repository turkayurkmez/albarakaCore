using System.ComponentModel.DataAnnotations;

namespace catalog.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz....")]
        //[MaxLength(150)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public int StockCount { get; set; } = 0;

        public int CategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public Category Category { get; set; }


    }
}

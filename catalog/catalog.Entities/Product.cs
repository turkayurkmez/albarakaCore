using System.ComponentModel.DataAnnotations;

namespace catalog.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz....")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public double? Rating { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int StockCount { get; set; }

        public Category Category { get; set; }


    }
}

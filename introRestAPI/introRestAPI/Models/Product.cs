using System.ComponentModel.DataAnnotations;

namespace introRestAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        public string Name { get; set; }

        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}

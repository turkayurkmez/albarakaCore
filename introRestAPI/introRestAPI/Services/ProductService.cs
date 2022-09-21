using introRestAPI.Models;

namespace introRestAPI.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ Id=1, Name="ABC", Description="Açıklama...", Price=1},
                new Product{ Id=2, Name="DEF", Description="Açıklama...", Price=5},
                new Product{ Id=3, Name="KLM", Description="Açıklama...", Price=10}

            };
        }
    }
}

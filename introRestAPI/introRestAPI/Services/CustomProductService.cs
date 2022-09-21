using introRestAPI.Models;

namespace introRestAPI.Services
{
    public class CustomProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ Id=11, Name="AAA", Description="Açıklama...", Price=1},
                new Product{ Id=12, Name="BBB", Description="Açıklama...", Price=5},
                new Product{ Id=13, Name="CCC", Description="Açıklama...", Price=10}

            };
        }
    }
}

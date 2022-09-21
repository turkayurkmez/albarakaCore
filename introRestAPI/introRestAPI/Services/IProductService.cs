using introRestAPI.Models;

namespace introRestAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}

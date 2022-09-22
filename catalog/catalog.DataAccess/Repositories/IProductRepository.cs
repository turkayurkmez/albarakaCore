using catalog.Entities;

namespace catalog.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> SearchProductsByName(string name);
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

    }
}

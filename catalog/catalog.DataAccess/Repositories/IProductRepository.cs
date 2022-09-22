using catalog.Entities;

namespace catalog.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);

    }
}

using catalog.Entities;

namespace catalog.DataAccess.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public Task Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

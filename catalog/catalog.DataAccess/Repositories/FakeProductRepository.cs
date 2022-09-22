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
            var products = new List<Product>()
            {
                new Product{ Id=1, Name="X", Price=5, Rating=4.2},
                new Product{ Id=2, Name="Y", Price=5, Rating=4.2},
                new Product{ Id=3, Name="Z", Price=5, Rating=4.2},

            };
            return Task.FromResult(products.AsEnumerable());
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

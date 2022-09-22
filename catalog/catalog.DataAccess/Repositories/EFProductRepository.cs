using catalog.DataAccess.Data;
using catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace catalog.DataAccess.Repositories
{
    public class EFProductRepository : IProductRepository
    {

        private readonly CatalogDbContext catalogDbContext;

        public EFProductRepository(CatalogDbContext catalogDbContext)
        {
            this.catalogDbContext = catalogDbContext;
        }

        public async Task Add(Product entity)
        {
            catalogDbContext.Products.Add(entity);

            await catalogDbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await catalogDbContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await catalogDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            var products = await catalogDbContext.Products.Where(p => p.Category.Id == categoryId).ToListAsync();
            return products;
        }

        public Task<IEnumerable<Product>> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

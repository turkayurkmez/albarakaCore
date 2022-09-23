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

        public async Task Delete(int id)
        {
            var product = await GetById(id);
            catalogDbContext.Products.Remove(product);
            await catalogDbContext.SaveChangesAsync();

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

        public async Task<bool> IsEntityExists(int id)
        {
            return await catalogDbContext.Products.AnyAsync(x => x.Id == id);
        }

        public Task<IEnumerable<Product>> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product entity)
        {
            catalogDbContext.Products.Update(entity);
            await catalogDbContext.SaveChangesAsync();


        }
    }
}

using catalog.Business.DTOs.Responses;
using catalog.DataAccess.Repositories;

namespace catalog.Business.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDisplayResponse>> GetProducts()
        {
            //AMAÇ: Veri kaynağından tüm ürünleri çek ve ProductDisplayResponse görünümüne dönüştür. 
            //Bir repository aracılığı ile veri kaynağından çek....

            var products = await productRepository.GetAll();
            var dto = products.Select(p => new ProductDisplayResponse
            {
                Description = p.Description,
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Rating = p.Rating
            });

            return dto;
        }
    }
}

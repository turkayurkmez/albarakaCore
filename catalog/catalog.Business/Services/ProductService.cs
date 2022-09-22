using catalog.Business.DTOs.Responses;

namespace catalog.Business.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<ProductDisplayResponse>> GetProducts()
        {
            //AMAÇ: Veri kaynağından tüm ürünleri çek ve ProductDisplayResponse görünümüne dönüştür. 
            //Bir repository aracılığı ile veri kaynağından çek....
            throw new NotImplementedException();
        }
    }
}

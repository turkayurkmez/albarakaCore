using catalog.Business.DTOs.Requests;
using catalog.Business.DTOs.Responses;

namespace catalog.Business.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDisplayResponse>> GetProducts();
        Task<ProductDisplayResponse> GetProduct(int id);

        Task<int> AddProduct(CreateProductRequest createProductRequest);
        Task<int> UpdateProduct(UpdateProductRequest updateProductRequest);
        Task Delete(int id);

    }
}

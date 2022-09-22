using catalog.Business.DTOs.Responses;

namespace catalog.Business.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDisplayResponse>> GetProducts();

    }
}

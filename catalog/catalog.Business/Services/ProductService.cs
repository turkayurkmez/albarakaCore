using AutoMapper;
using catalog.Business.DTOs.Requests;
using catalog.Business.DTOs.Responses;
using catalog.DataAccess.Repositories;
using catalog.Entities;

namespace catalog.Business.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddProduct(CreateProductRequest createProductRequest)
        {
            //var product = new Product
            //{
            //    Name = createProductRequest.Name,
            //    Price = createProductRequest.Price,
            //    Description = createProductRequest.Description,
            //    Rating = createProductRequest.Rating,
            //    CategoryId = createProductRequest.CategoryId,
            //};

            var product = mapper.Map<Product>(createProductRequest);

            await productRepository.Add(product);
            return product.Id;

        }

        public async Task Delete(int id)
        {
            await productRepository.Delete(id);
        }


        public async Task<ProductDisplayResponse> GetProduct(int id)
        {
            var product = await productRepository.GetById(id);
            var response = mapper.Map<ProductDisplayResponse>(product);
            return response;
            //return new ProductDisplayResponse
            //{
            //    Description = product.Description,
            //    Id = product.Id,
            //    Name = product.Name,
            //    Price = product.Price,
            //    Rating = product.Rating
            //};
        }

        public async Task<IEnumerable<ProductDisplayResponse>> GetProducts()
        {
            //AMAÇ: Veri kaynağından tüm ürünleri çek ve ProductDisplayResponse görünümüne dönüştür. 
            //Bir repository aracılığı ile veri kaynağından çek....

            var products = await productRepository.GetAll();
            var dto = mapper.Map<IEnumerable<ProductDisplayResponse>>(products);
            //var dto = products.Select(p => new ProductDisplayResponse
            //{
            //    Description = p.Description,
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price,
            //    Rating = p.Rating
            //});

            return dto;
        }

        public async Task<bool> IsEntityExists(int id)
        {
            return await productRepository.IsEntityExists(id);
        }

        public async Task<int> UpdateProduct(UpdateProductRequest updateProductRequest)
        {
            //var product = new Product
            //{
            //    CategoryId = updateProductRequest.CategoryId,
            //    Description = updateProductRequest.Description,
            //    Id = updateProductRequest.Id,
            //    Name = updateProductRequest.Name,
            //    Price = updateProductRequest.Price,
            //    Rating = updateProductRequest.Rating
            //};

            var product = mapper.Map<Product>(updateProductRequest);

            await productRepository.Update(product);
            return product.Id;



        }
    }
}

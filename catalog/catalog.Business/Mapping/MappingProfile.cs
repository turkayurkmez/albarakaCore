using AutoMapper;
using catalog.Business.DTOs.Requests;
using catalog.Business.DTOs.Responses;
using catalog.Entities;

namespace catalog.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDisplayResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();

        }
    }
}

using AutoMapper;
using ProductManager.Application.Dto;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Domain.Entities;

namespace ProductManager.Application.UseCases.Commons.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}


using AutoMapper;
using Moq;
using ProductManager.Application.Dto;
using ProductManager.Application.UnitTests.MockData;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Enums;
using ProductManager.Domain.Repositories;

namespace ProductManager.Application.UnitTests.UseCasesTests.BaseTests
{
    public class BaseProductHandlerTest
    {
        protected readonly Mock<IProductRepository> ProductRepository;
        protected readonly IMapper Mapper;

        protected BaseProductHandlerTest(List<Product>? products = null)
        {
            products ??= ProductMockData.FakeProducts;

            ProductRepository =  MockProductRepository.GetMockProductRepository(products);
           
            var mapperConfig = new MapperConfiguration(cfg => {

                cfg.CreateMap<CreateProductCommand, Product>()
                    .ForMember(dst => dst.Name, src => src.MapFrom<string>(src => src.Name))
                    .ForMember(dst => dst.Description, src => src.MapFrom<string>(src => src.Description))
                    .ForMember(dst => dst.Colour, src => src.MapFrom<ProductColor>(src => src.Colour))
                    .ForMember(dst => dst.Price, src => src.MapFrom<double>(src => src.Price));

                cfg.CreateMap<Product, ProductDto>()
                   .ForMember(dst => dst.Id, src => src.MapFrom<Guid>(src => src.Id))
                   .ForMember(dst => dst.Name, src => src.MapFrom<string>(src => src.Name))
                   .ForMember(dst => dst.Description, src => src.MapFrom<string>(src => src.Description))
                   .ForMember(dst => dst.Colour, src => src.MapFrom<ProductColor>(src => src.Colour))
                   .ForMember(dst => dst.Price, src => src.MapFrom<double>(src => src.Price));

            });

            Mapper = mapperConfig.CreateMapper();
           

        }
    }
}

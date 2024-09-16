using AutoMapper;
using Moq;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Domain.Entities;

namespace ProductManager.Application.UnitTests.MockData
{

    public static  class ProductMappingMock
    {
        public static Mock<IMapper> MappingData(CreateProductCommand productCommand, Product product)
        {
            var mappingService = new Mock<IMapper>();

            mappingService.Setup(m => m.Map<CreateProductCommand, Product>(productCommand)).Returns(product);

            return mappingService;
        }
    }
}
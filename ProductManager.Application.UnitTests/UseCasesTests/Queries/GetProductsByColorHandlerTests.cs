using AutoMapper;
using FluentAssertions;
using ProductManager.Application.Dto;
using ProductManager.Application.UnitTests.MockData;
using ProductManager.Application.UnitTests.UseCasesTests.BaseTests;
using ProductManager.Application.UseCases.Products.Queries.GetProductsByColor;
using ProductManager.Domain.Constants;
using ProductManager.Domain.Enums;


namespace ProductManager.Application.UnitTests.UseCasesTests.Queries
{
    public class GetProductsByColorHandlerTests() : BaseProductHandlerTest(ProductMockData.FakeProductListWith3Blues)
    {
        //prepare repository with 3 Blue products 

        [Theory]
        [InlineData(ProductColor.Blue, 3)]
        [InlineData(ProductColor.Yellow, 2)]
        [InlineData(ProductColor.Red, 1)]
        public async Task Handle_Should_Return_ProductsForSpecific_Color_Tests(ProductColor color, int noOfProducts)
        {
            // Arrange
            GetProductsByColorQuery getProductByColorQuery = new GetProductsByColorQuery(color);
            var getProductByColorHandler = new GetProductsByColorHandler(ProductRepository.Object, Mapper);

            //Act
            var response = await getProductByColorHandler.Handle(getProductByColorQuery, default);

            //Assert
            response.succcess.Should().BeTrue();
            response.Data.Should().BeOfType<List<ProductDto>>();
            response.Data?.Count().Should().Be(noOfProducts);
            response.Message.Should().Be(GenericMessages.ProductByColorQuerySuccessMsg);
        }
    }
}

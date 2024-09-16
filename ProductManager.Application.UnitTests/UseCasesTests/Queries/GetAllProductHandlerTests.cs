using FluentAssertions;
using ProductManager.Application.Dto;
using ProductManager.Application.UnitTests.UseCasesTests.BaseTests;
using ProductManager.Application.UseCases.Products.Queries.GetAllProductsQuery;
using ProductManager.Domain.Constants;


namespace ProductManager.Application.UnitTests.UseCasesTests.Queries
{
    public class GetAllProductHandlerTests : BaseProductHandlerTest
    {
        [Fact]
        public async Task Handle_Should_Return_All_Tests()
        {
            // Arrange
            GetAllProductsQuery getAllProductQuery = new GetAllProductsQuery();
            var getAllProductHandler = new GetAllProductsHandler(ProductRepository.Object, Mapper);
            
            //Act
            var response = await getAllProductHandler.Handle(getAllProductQuery, default);

            //Assert
            response.succcess.Should().BeTrue();
            response.Data.Should().BeOfType<List<ProductDto>>();
            response.Message.Should().Be(GenericMessages.AllProductQuerySuccessMsg);
        }


    }
}

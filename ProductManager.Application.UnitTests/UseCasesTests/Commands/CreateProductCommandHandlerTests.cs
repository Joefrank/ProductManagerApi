using FluentAssertions;
using ProductManager.Application.UnitTests.MockData;
using ProductManager.Application.UnitTests.UseCasesTests.BaseTests;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Domain.Constants;

namespace ProductManager.Application.UnitTests.UseCasesTests.Commands
{
   
    public class CreateProductHandlerTests : BaseProductHandlerTest
    {
        [Fact]
        public async Task Handle_Should_CreateProduct_FromCommand()
        {

            // Arrange
            CreateProductCommand createProductCommand = ProductMockData.GetDefaultProductCommand();
            var createProductHandler = new CreateProductHandler(ProductRepository.Object, Mapper);

            //Act
            var response = await createProductHandler.Handle(createProductCommand,default);

            //Assert
            response.Should().NotBeNull();
            response.succcess.Should().BeTrue();
            response.Message.Should().Be(GenericMessages.ProductCreatedSuccessMsg);
        }
    }
}

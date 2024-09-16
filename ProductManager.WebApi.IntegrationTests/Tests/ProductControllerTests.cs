using System.Net;
using System.Net.Http.Json;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.WebApi.IntegrationTests.Model;
using ProductManager.WebApi.IntegrationTests.Model.Constants;

namespace ProductManager.WebApi.IntegrationTests.Tests;


public class ProductControllerTests :  IClassFixture<ProductManagerWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ProductControllerTests(ProductManagerWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
       
    }

    [Theory]
    [InlineData(URI.ProductGetAllEndPoint)]
    [InlineData(URI.ProductGetAllByColorAsyncEndPoint)]
    public async Task GetProdMethods_Returns_Unauthorized_When_NoToken_Provided(string endPoint)
    {
       
        // Act
        var response = await _client.GetAsync(endPoint);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact] 
    public async Task CreateProdMethods_Returns_Unauthorized_When_NoToken_Provided()
    {
        //Arrange
        var createProductCommand = new CreateProductCommand { Name = "Product Dummy", Description = "This is product From Test", Price = 10.5d, Colour = Domain.Enums.ProductColor.Purple };

        // Act
        var response = await _client.PostAsJsonAsync(URI.ProductCreateAsyncEndPoint, createProductCommand);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

   
}
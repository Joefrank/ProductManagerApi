using FluentAssertions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Application.Dto;
using ProductManager.Application.UseCases.Commons.Bases;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Domain.Constants;
using ProductManager.Domain.Enums;
using ProductManager.WebApi.IntegrationTests.Model;
using ProductManager.WebApi.IntegrationTests.Model.Constants;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;


namespace ProductManager.WebApi.IntegrationTests.Tests
{
    
    public class ProductControllerTestWithFakeAuth : IClassFixture<ProductManagerWebApplicationFactory>
    {
        private readonly HttpClient _client;
       
        public ProductControllerTestWithFakeAuth(ProductManagerWebApplicationFactory factory)
        {
           
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {                    
                    services.AddAuthentication("TestScheme")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("TestScheme", options => { });
                });
            }).CreateClient();
           
        }

        [Fact]
        public async Task GetAllAsync_Returns_List_Of_Products_When_Authorized()
        {
            // Act
            var response = await _client.GetAsync(URI.ProductGetAllEndPoint);

            var result = await response.Content.ReadAsStringAsync();
            var returnObject = JsonSerializer.Deserialize<List<ProductDto>>(result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            returnObject.Should().BeOfType<List<ProductDto>>();
            returnObject.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetAllByColorAsync_Returns_List_Of_Filtered_Products_When_Authorized()
        {
            //we know that OnModelCreating seeds 3 products and there are 2 of them with blue color. we can use this for our test.
            //Arrange
            var testColor = ProductColor.Blue;
            var url = string.Format(URI.ProductGetAllByColorAsyncEndPoint, (int)testColor);

            // Act
            var response = await _client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();
            var returnObject = JsonSerializer.Deserialize<List<ProductDto>>(result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            returnObject.Should().BeOfType<List<ProductDto>>();
            returnObject.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task CreateAsync_Returns_CorrectResponse_When_Authorized()
        {
            //we know that OnModelCreating seeds 3 products and there are 2 of them with blue color. we can use this for our test.
            //Arrange
            var command = new CreateProductCommand
            {
                Name = "Product Dummy",
                Description = "This is product From Test",
                Price = 10.5d,
                Colour = Domain.Enums.ProductColor.Purple
            };

            // Act           
            var response = await _client.PostAsJsonAsync(URI.ProductCreateAsyncEndPoint, command);

            var result = await response.Content.ReadAsStringAsync();
            var returnObject = JsonSerializer.Deserialize<BaseResponse<bool>>(result,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            returnObject.succcess.Should().BeTrue();
            returnObject.Message.Should().Be(GenericMessages.ProductCreatedSuccessMsg);
        }

    }
}

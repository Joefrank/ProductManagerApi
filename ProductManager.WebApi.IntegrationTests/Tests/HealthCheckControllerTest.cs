using ProductManager.WebApi.IntegrationTests.Model.Constants;
using ProductManager.WebApi.IntegrationTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Application.Dto;
using System.Text.Json;
using FluentAssertions;
using ProductManager.Domain.Constants;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ProductManager.WebApi.IntegrationTests.Tests
{
    public class HealthCheckControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public HealthCheckControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();

        }

        [Fact]
        public async Task CheckAppIsAlive_Returns_Correct_Message()
        {

            // Act
            var response = await _client.GetAsync(URI.HealthCheckEndPoint);
            var result = await response.Content.ReadAsStringAsync();            

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            result.Should().Be(GenericMessages.AppIsAliveMsg);

        }
    }
}

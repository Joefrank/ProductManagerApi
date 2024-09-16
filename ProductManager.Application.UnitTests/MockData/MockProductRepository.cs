using Moq;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Enums;
using ProductManager.Domain.Repositories;

namespace ProductManager.Application.UnitTests.MockData
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetMockProductRepository(List<Product> products)
        {          
            
            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(products);

            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                .ReturnsAsync((Product product) => 
                {
                    products.Add(product);
                    return 1;
                });

            mockRepo.Setup(repo => repo.GetProductByColour(It.IsAny<ProductColor>()))
                .ReturnsAsync((ProductColor color) =>
                {
                    return products.Where(p => p.Colour == color).ToList();
                });

            return mockRepo;
        }
    }
}

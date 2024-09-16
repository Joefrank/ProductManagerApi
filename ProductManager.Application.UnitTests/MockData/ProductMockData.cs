
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Domain.Entities;

namespace ProductManager.Application.UnitTests.MockData
{
    public static class ProductMockData
    {
        public static CreateProductCommand GetDefaultProductCommand()
        {
            var command = new CreateProductCommand
            {
                Name = "Product Dummy",
                Description = "This is product From Test",
                Price = 10.5d,
                Colour = Domain.Enums.ProductColor.Purple
            };
            return command;
        }

        public static Product GetDefaultProduct() => new Product { Name = "Product Dummy", Description = "This is product from test", Price = 12.5d, Colour = Domain.Enums.ProductColor.Purple };

        public static List<Product> FakeProducts =>
        [
            new Product()
            {
                Id = Guid.NewGuid(), Name = "Product 1", Description = "This is product 1", Price = 12.5d,
                Colour = Domain.Enums.ProductColor.Blue
            },
            new Product()
            {
                Id = Guid.NewGuid(), Name = "Product 2", Description = "This is product 2", Price = 2.6d,
                Colour = Domain.Enums.ProductColor.Red
            },
            new Product()
            {
                Id = Guid.NewGuid(), Name = "Product 3", Description = "This is product 3", Price = 5.05d,
                Colour = Domain.Enums.ProductColor.Blue
            }
        ];

        // this list is for testing filter by colour.
        public static List<Product> FakeProductListWith3Blues =>
           new List<Product>()
           {
                 new Product() {Id = Guid.NewGuid(), Name = "Product Blue 1", Description="This is product 1", Price = 12.5d, Colour = Domain.Enums.ProductColor.Blue },
                 new Product() { Id = Guid.NewGuid(), Name = "Product 2", Description = "This is product 2", Price = 2.6d, Colour = Domain.Enums.ProductColor.Red },
                 new Product() { Id = Guid.NewGuid(), Name = "Product Blue 3", Description = "This is product 3", Price = 5.05d, Colour = Domain.Enums.ProductColor.Blue },
                 new Product() { Id = Guid.NewGuid(), Name = "Product 4", Description = "This is product 3", Price = 5.05d, Colour = Domain.Enums.ProductColor.Yellow },
                 new Product() { Id = Guid.NewGuid(), Name = "Product Blue 5", Description = "This is product 3", Price = 5.05d, Colour = Domain.Enums.ProductColor.Blue },
                 new Product() { Id = Guid.NewGuid(), Name = "Product Blue 5", Description = "This is product 3", Price = 5.05d, Colour = Domain.Enums.ProductColor.Yellow }
           };
    }
}


using Microsoft.AspNetCore.Identity;
using ProductManager.Domain.Entities;
using ProductManager.Persistence.Contexts;

namespace ProductManager.Persistence
{
    public class DataSeeder
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ProductDbContext _dbContext;

        public DataSeeder(UserManager<AppUser> userManager, ProductDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task CreateDefaultProductsAsync()
        {
            var productsToAdd = new List<Product>()
            {
                new Product() { Id = Guid.NewGuid(), Name = "Product 111", Description="This is product 1", Price = 12.5d, Colour = Domain.Enums.ProductColor.Blue, CreatedDate = DateTime.Now },
                new Product() { Id = Guid.NewGuid(), Name = "Product 222", Description = "This is product 2", Price = 2.6d, Colour = Domain.Enums.ProductColor.Red, CreatedDate = DateTime.Now },
                new Product() { Id = Guid.NewGuid(), Name = "Product 333", Description = "This is product 3", Price = 5.05d, Colour = Domain.Enums.ProductColor.Blue, CreatedDate = DateTime.Now }
            };

            var allProducts = _dbContext.Set<Product>();

            foreach (var product in productsToAdd)
            {
                if (!allProducts.Any(p => p.Name == product.Name))
                    _dbContext.Products.Add(product);
            }
           
            await _dbContext.SaveChangesAsync();
        }
    }
}

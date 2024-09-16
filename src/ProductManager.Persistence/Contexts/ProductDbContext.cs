using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;

namespace ProductManager.Persistence.Contexts
{
    public class ProductDbContext : IdentityDbContext<AppUser>
    {
        public ProductDbContext()   //used for testing/mocking         
        {           
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) 
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public virtual DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            //seeding some product data for the testing
            //modelBuilder.Entity<Product>().HasData(
            //    new Product() {Id = Guid.NewGuid(), Name = "Product 1", Description="This is product 1", Price = 12.5d, Colour = Domain.Enums.ProductColor.Blue, CreatedDate = DateTime.Now },
            //    new Product() { Id = Guid.NewGuid(), Name = "Product 2", Description = "This is product 2", Price = 2.6d, Colour = Domain.Enums.ProductColor.Red, CreatedDate = DateTime.Now },
            //    new Product() { Id = Guid.NewGuid(), Name = "Product 3", Description = "This is product 3", Price = 5.05d, Colour = Domain.Enums.ProductColor.Blue, CreatedDate = DateTime.Now }
            //);
        }       
    }
}


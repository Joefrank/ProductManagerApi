using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Enums;
using ProductManager.Domain.Repositories;
using ProductManager.Persistence.Contexts;


namespace ProductManager.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _productDbContext.Products.FirstAsync(p => p.Id == id);
        }
        public async Task<int> AddAsync(Product product)
        {
            await _productDbContext.Products.AddAsync(product);
            var result = await _productDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<int> UpdateAsync(Product product)
        {
            _productDbContext.Products.Update(product);
            var result = await _productDbContext.SaveChangesAsync();
            return result;
        }
        public async Task DeleteAsync(Product product)
        {
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var products = await _productDbContext.Products.AsNoTracking().ToListAsync();
            return products;
        }

        public async Task<IReadOnlyList<Product>> GetProductByColour(ProductColor color)
        {
            IQueryable<Product> products = _productDbContext.Products.Where(p => p.Colour == color);
            return await products.AsNoTracking().ToListAsync();
        }
    }
}

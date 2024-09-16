
using ProductManager.Domain.Entities;
using ProductManager.Domain.Enums;

namespace ProductManager.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(Guid id);
        Task<int> AddAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<IReadOnlyList<Product>> GetProductByColour(ProductColor color);
    }
}

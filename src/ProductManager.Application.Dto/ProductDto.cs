using ProductManager.Domain.Enums;

namespace ProductManager.Application.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public ProductColor Colour { get; set; }
    }
}

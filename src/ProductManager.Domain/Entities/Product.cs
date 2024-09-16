
using ProductManager.Domain.Entities.Base;
using ProductManager.Domain.Enums;

namespace ProductManager.Domain.Entities
{
    public class Product : BaseAuditEntity<Guid>
    {       
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public ProductColor Colour { get; set; }
        
    }

}

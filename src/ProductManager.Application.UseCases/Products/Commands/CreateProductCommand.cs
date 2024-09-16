using MediatR;
using ProductManager.Application.UseCases.Commons.Bases;
using ProductManager.Domain.Enums;

namespace ProductManager.Application.UseCases.Products.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse<bool>>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public double Price { get; set; }
        public ProductColor Colour { get; set; }
    }
}

using MediatR;
using ProductManager.Application.Dto;
using ProductManager.Application.UseCases.Commons.Bases;
using ProductManager.Domain.Enums;

namespace ProductManager.Application.UseCases.Products.Queries.GetProductsByColor
{
    public class GetProductsByColorQuery : IRequest<BaseResponse<IEnumerable<ProductDto>>>
    {
        public ProductColor ProductColor { get; set; }
        public GetProductsByColorQuery(ProductColor color) {
            ProductColor = color;
        }
    }
}

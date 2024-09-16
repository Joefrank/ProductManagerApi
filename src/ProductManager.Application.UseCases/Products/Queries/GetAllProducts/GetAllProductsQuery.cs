using MediatR;
using ProductManager.Application.Dto;
using ProductManager.Application.UseCases.Commons.Bases;


namespace ProductManager.Application.UseCases.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<BaseResponse<IEnumerable<ProductDto>>>
    {
    }
}

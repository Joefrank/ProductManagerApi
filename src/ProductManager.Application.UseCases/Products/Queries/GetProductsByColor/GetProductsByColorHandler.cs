using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManager.Application.Dto;
using ProductManager.Application.Interface.Persistence;
using ProductManager.Application.UseCases.Commons.Bases;
using ProductManager.Domain.Constants;
using ProductManager.Domain.Repositories;
using ProductManager.Persistence.Contexts;
using ProductManager.Persistence.Repositories;


namespace ProductManager.Application.UseCases.Products.Queries.GetProductsByColor
{
    public class GetProductsByColorHandler  : IRequestHandler<GetProductsByColorQuery, BaseResponse<IEnumerable<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByColorHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<IEnumerable<ProductDto>>> Handle(GetProductsByColorQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<ProductDto>>();

            try
            {
                var products = await _productRepository.GetProductByColour(request.ProductColor);

                if (products is not null)
                {
                    response.Data = _mapper.Map<List<ProductDto>>(products);
                    response.succcess = true;
                    response.Message = GenericMessages.ProductByColorQuerySuccessMsg;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

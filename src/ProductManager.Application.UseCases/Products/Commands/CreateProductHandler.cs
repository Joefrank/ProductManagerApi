using AutoMapper;
using MediatR;
using ProductManager.Application.UseCases.Commons.Bases;
using ProductManager.Domain.Constants;
using ProductManager.Domain.Entities;
using ProductManager.Domain.Repositories;


namespace ProductManager.Application.UseCases.Products.Commands
{
    internal sealed class CreateProductHandler :  IRequestHandler<CreateProductCommand, BaseResponse<bool>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var product = _mapper.Map<Product>(command);
                product.Id = Guid.NewGuid();
                product.CreatedDate = DateTime.UtcNow;

                var result = await _productRepository.AddAsync(product);
               
                if (result > 0)
                {
                    response.succcess = true;
                    response.Message = GenericMessages.ProductCreatedSuccessMsg;
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

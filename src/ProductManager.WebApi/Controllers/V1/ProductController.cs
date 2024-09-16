using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.UseCases.Products.Commands;
using ProductManager.Application.UseCases.Products.Queries.GetAllProductsQuery;
using ProductManager.Application.UseCases.Products.Queries.GetProductsByColor;
using ProductManager.Domain.Enums;

namespace ProductManager.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllProductsQuery());
            if (response.succcess)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllByColor")]
        public async Task<IActionResult> GetAllByColorAsync(ProductColor color)
        {           
            var response = await _mediator.Send(new GetProductsByColorQuery(color));
            if (response.succcess)
            {
                return Ok(response.Data);
            }
            return BadRequest(response);
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] CreateProductCommand? command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}

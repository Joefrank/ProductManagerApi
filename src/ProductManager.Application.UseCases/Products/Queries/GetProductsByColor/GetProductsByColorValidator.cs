using FluentValidation;

namespace ProductManager.Application.UseCases.Products.Queries.GetProductsByColor
{
    public class GetProductsByColorValidator : AbstractValidator<GetProductsByColorQuery>
    {
        public GetProductsByColorValidator()
        {
            RuleFor(x => x.ProductColor)
                .NotNull()
                .NotEmpty();
        }
    }
}

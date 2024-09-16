using FluentValidation;


namespace ProductManager.Application.UseCases.Products.Commands
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidation()
        {            
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Colour).NotEmpty().NotNull();
        }
    }
}

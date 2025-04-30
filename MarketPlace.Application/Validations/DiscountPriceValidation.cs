using FluentValidation;
using MarketPlace.Dto.Products.Pricing;

namespace MarketPlace.Application.Validations
{
    public class DiscountPriceValidation : AbstractValidator<DiscountPriceRequestDto>
    {
        public DiscountPriceValidation()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.VariableProductId)
                .NotEqual(x => x.ProductId)
                .WithMessage("variable product id cannot be the same as the main product id.");

            RuleFor(x => x.SalePrice)
                .GreaterThan(0);
        }
    }
}

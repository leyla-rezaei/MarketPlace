using FluentValidation;
using MarketPlace.Dto.Products.Pricing;

namespace MarketPlace.Application.Validations
{
    public class PriceValidation : AbstractValidator<PriceRequestDto>
    {
        public PriceValidation()
        {
            RuleFor(x => x.SalePrice)
                .NotNull();
        }
    }
}

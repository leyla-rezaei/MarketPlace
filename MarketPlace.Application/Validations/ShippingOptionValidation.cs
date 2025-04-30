using FluentValidation;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Validations
{
    public class ShippingOptionValidation : AbstractValidator<ShippingOptionRequestDto>
    {
        public ShippingOptionValidation()
        {
            RuleFor(x => x.IsEnableShippingCalculatorOnCartPage)
                .NotNull();

            RuleFor(x => x.HideShippingCostsUntilAddressIsEntered)
                .NotNull();

            RuleFor(x => x.ShippingDestination)
                .NotNull();

            RuleFor(x => x.StoreId)
                .NotNull();
        }
    }
}

using FluentValidation;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Validations
{
    public class ShippingMethodValidation : AbstractValidator<ShippingMethodRequestDto>
    {
        public ShippingMethodValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.IsEnabled)
                .NotNull();

            RuleForEach(x => x.Localizations)
             .SetValidator(new ShippingMethodLocalizationValidation());
        }
        public class ShippingMethodLocalizationValidation : AbstractValidator<ShippingMethodLocalizationDto>
        {
            public ShippingMethodLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.MethodTitle) 
                 .NotEmpty();
            }
        }
    }
}
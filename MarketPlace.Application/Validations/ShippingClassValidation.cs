using FluentValidation;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Validations
{
    public class ShippingClassValidation : AbstractValidator<ShippingClassRequestDto>
    {
        public ShippingClassValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.ProductCount)
                .GreaterThanOrEqualTo(0);

            RuleForEach(x => x.Localizations)
             .SetValidator(new ShippingClassLocalizationValidation());
        }

        public class ShippingClassLocalizationValidation : AbstractValidator<ShippingClassLocalizationDto>
        {
            public ShippingClassLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Slug)
                    .NotNull();

                RuleFor(x => x.ClassName)
                    .NotEmpty();
            }
        }
    }
}

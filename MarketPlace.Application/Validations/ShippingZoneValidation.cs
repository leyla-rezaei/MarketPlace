using FluentValidation;
using MarketPlace.Dto.StoretSettings.Shippings;

namespace MarketPlace.Application.Validations
{
    public class ShippingZoneValidation : AbstractValidator<ShippingZoneRequestDto>
    {
        public ShippingZoneValidation()
        {
            RuleFor(x => x.ZoneRegionId)
                .NotNull();

            RuleForEach(x => x.Localizations)
           .SetValidator(new ShippingZoneLocalizationValidation());
        }

        public class ShippingZoneLocalizationValidation : AbstractValidator<ShippingZoneLocalizationDto>
        {
            public ShippingZoneLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.ZoneName).NotNull();

            }
        }
    }
}
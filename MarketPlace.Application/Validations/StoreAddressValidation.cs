using FluentValidation;
using MarketPlace.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public class StoreAddressValidation : AbstractValidator<StoreAddressRequestDto>
    {
        public StoreAddressValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.CityId)
                .NotNull();

            RuleForEach(x => x.Localizations) 
                .SetValidator(new StoreAddressLocalizationValidation());
        }

        public class StoreAddressLocalizationValidation : AbstractValidator<StoreAddressLocalizationDto>
        {
            public StoreAddressLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Address)
                    .NotEmpty();

                RuleFor(x => x.ZipCode)
                    .NotEmpty();

                RuleFor(x => x.PostalCode)
                    .NotEmpty()
                    .Length(10);
            }
        }
    }
}

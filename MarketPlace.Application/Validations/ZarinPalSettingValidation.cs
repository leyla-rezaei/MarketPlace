using FluentValidation;
using MarketPlace.Dto.StoretSettings.Selling.PayGateSetting;

namespace MarketPlace.Application.Validations
{
    public class ZarinPalSettingValidation : AbstractValidator<ZarinPalSettingRequestDto>
    {
        public ZarinPalSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.IsEanbled)
                .NotNull();

            RuleForEach(x => x.Localizations)
                .SetValidator(new ZarinPalSettingLocalizationValidation());
        }

        public class ZarinPalSettingLocalizationValidation : AbstractValidator<ZarinPalSettingLocalizationDto>
        {
            public ZarinPalSettingLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.MerchentCode)
                .NotEmpty()
                .MaximumLength(50);

            }
        }
    }
}
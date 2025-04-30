using FluentValidation;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public class StoreGeneralSettingValidation : AbstractValidator<StoreGeneralSettingRequestDto>
    {
        public StoreGeneralSettingValidation()
        {
            RuleFor(x => x.StoreId)
               .NotNull();

            RuleFor(x => x.StoreSubDomian)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9-]*$")
                .WithMessage("invalid characters in store sub domian.");

            RuleFor(x => x.StoreSubDomianUrl)
                .NotEmpty();

            RuleFor(x => x.StoreLanguageId)
                .NotNull();

            RuleFor(x => x.TimeZoneId)
                .NotNull();

            RuleFor(x => x.CustomDateFormat)
                .MaximumLength(20);

            RuleFor(x => x.CustomTimeFormat)
                .MaximumLength(20);

            RuleForEach(x => x.Localizations)
                 .SetValidator(new StoreGeneralSettingLocalizationValidation());
        }

        public class StoreGeneralSettingLocalizationValidation : AbstractValidator<StoreGeneralSettingLocalizationDto>
        {
            public StoreGeneralSettingLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Title)
                    .NotEmpty();
            }
        }
    }
}

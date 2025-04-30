using FluentValidation;
using MarketPlace.Dto.StoretSettings.Selling.PayGateSetting;

namespace MarketPlace.Application.Validations
{
    public class PayPalSettingValidation : AbstractValidator<PayPalSettingRequestDto>
    {
        public PayPalSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(dto => dto.IsEanbled)
                .NotNull();

            RuleFor(x => x.RequestRetries)
                .GreaterThanOrEqualTo(0)
                .WithMessage("request retries must be greater than or equal to 0.");

            RuleFor(x => x.ConnectionTimeout)
                .GreaterThan(0)
                .WithMessage("connection timeout must be greater than 0.");

            RuleForEach(x => x.Localizations)
                .SetValidator(new PayPalSettingLocalizationValidation());
        }

        public class PayPalSettingLocalizationValidation : AbstractValidator<PayPalSettingLocalizationDto>
        {
            public PayPalSettingLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Mode)
                    .NotNull();
            }
        }
    }
}

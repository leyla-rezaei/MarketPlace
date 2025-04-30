using FluentValidation;
using MarketPlace.Dto.StoretSettings.Slider;

namespace MarketPlace.Application.Validations
{
    public class StoreSliderValidation : AbstractValidator<StoreSliderRequestDto>
    {
        public StoreSliderValidation()
        {
            RuleForEach(x => x.Localizations)
                .SetValidator(new StoreSliderLocalizationValidation());
        }
    }

    public class StoreSliderLocalizationValidation : AbstractValidator<StoreSliderLocalizationDto>
    {
        public StoreSliderLocalizationValidation()
        {
            RuleFor(x => x.Key)
                .NotEmpty();

            RuleFor(x => x.SliderName)
                    .NotEmpty();
        }
    }
}

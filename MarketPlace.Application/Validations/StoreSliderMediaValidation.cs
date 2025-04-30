using FluentValidation;
using MarketPlace.Dto.StoretSettings.Slider;

namespace MarketPlace.Application.Validations
{
    public class StoreSliderMediaValidation : AbstractValidator<StoreSliderMediaRequestDto>
    {
        public StoreSliderMediaValidation()
        {
            RuleFor(x => x.StoreSliderId)
                .NotNull();

            RuleFor(x => x.MultiMediaFileId)
               .NotNull();

            RuleFor(x => x.Order)
             .NotNull();
        }
    }
}

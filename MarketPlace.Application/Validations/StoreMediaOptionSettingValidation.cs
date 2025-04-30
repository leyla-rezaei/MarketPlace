using FluentValidation;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public class StoreMediaOptionSettingValidation :AbstractValidator<StoreMediaOptionSettingRequestDto>
    {
        public StoreMediaOptionSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.ThumbnailWidth)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ThumbnailWidth.HasValue);

            RuleFor(x => x.ThumbnailHeight)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ThumbnailHeight.HasValue);

            RuleFor(x => x.MediumSizeMaxWidth)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MediumSizeMaxWidth.HasValue);

            RuleFor(x => x.MediumSizeMaxHeight)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MediumSizeMaxHeight.HasValue);

            RuleFor(x => x.LargeSizeMaxWidth)
                .GreaterThanOrEqualTo(0)
                .When(x => x.LargeSizeMaxWidth.HasValue);

            RuleFor(x => x.LargeSizeMaxHeight)
                .GreaterThanOrEqualTo(0)
                .When(x => x.LargeSizeMaxHeight.HasValue);
        }
    }
}

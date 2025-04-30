using FluentValidation;
using MarketPlace.Dto.Admin;

namespace MarketPlace.Application.Validations
{
    public class MainStoreMediaOptionSettingValidation : AbstractValidator<MainStoreMediaOptionSettingRequestDto>
    {
        public MainStoreMediaOptionSettingValidation()
        {
            RuleFor(x => x.ThumbnailWidth)
                .GreaterThan(0)
                .WithMessage("thumbnail width must be greater than zero.");

            RuleFor(x => x.ThumbnailHeight)
                .GreaterThan(0)
                .WithMessage("thumbnail height must be greater than zero.");

            RuleFor(x => x.MediumSizeMaxWidth)
                .GreaterThan(0)
                .WithMessage("medium size maximum width must be greater than zero.");

            RuleFor(x => x.MediumSizeMaxHeight)
                .GreaterThan(0)
                .WithMessage("medium size maximum height must be greater than zero.");

            RuleFor(x => x.LargeSizeMaxWidth)
                .GreaterThan(0)
                .WithMessage("large size maximum width must be greater than zero.");

            RuleFor(x => x.LargeSizeMaxHeight)
                .GreaterThan(0)
                .WithMessage("large size maximum height must be greater than zero.");
        }
    }
}

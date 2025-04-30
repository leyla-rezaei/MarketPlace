using FluentValidation;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public class StoreWritingSettingValidation : AbstractValidator<StoreWritingSettingRequestDto>
    {
        public StoreWritingSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.DefaultPostCategoryId)
                .NotNull();

            RuleFor(x => x.DefaultPostFormat)
               .NotNull();
        }
    }
}

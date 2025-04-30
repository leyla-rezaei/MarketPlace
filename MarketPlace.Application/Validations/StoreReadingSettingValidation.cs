using FluentValidation;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Validations
{
    public  class StoreReadingSettingValidation : AbstractValidator<StoreReadingSettingRequestDto>
    {
        public StoreReadingSettingValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.HomepageDisplay)
                .NotNull();

            RuleFor(x => x.HomePageId)
                .NotNull();
            RuleFor(x => x.PostsPageId)
                .NotNull();

            RuleFor(x => x.BlogPagesShowAtMost)
                .GreaterThan(0);
        }
    }
}

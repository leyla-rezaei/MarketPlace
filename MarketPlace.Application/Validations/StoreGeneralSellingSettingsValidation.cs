using FluentValidation;
using MarketPlace.Dto.StoretSettings.Selling.Setting;

namespace MarketPlace.Application.Validations
{
    public class StoreGeneralSellingSettingsValidation : AbstractValidator<StoreGeneralSellingSettingsRequestDto>
    {
        public StoreGeneralSellingSettingsValidation()
        {
            RuleFor(x => x.StoreId)
             .NotNull();

            RuleFor(x => x.CurrencyId)
                .NotNull();

            RuleFor(x => x.WeightUnit)
                .NotNull();

            RuleFor(x => x.DimensionsUnit)
                 .NotNull();

            RuleFor(x => x.IsEnableStarRatingOnProductReviews)
                .NotNull();

            RuleFor(x => x.IsProductStarRatingsRequired)
                .NotNull();
        }
    }
}

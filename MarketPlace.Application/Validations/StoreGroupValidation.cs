using FluentValidation;
using MarketPlace.Dto.StoretSettings.Users;

namespace MarketPlace.Application.Validations
{
    public class StoreGroupValidation : AbstractValidator<StoreGroupRequestDto>
    {
        public StoreGroupValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleForEach(x => x.Localizations)
                .SetValidator(new StoreGroupLocalizationValidation());
        }
        public class StoreGroupLocalizationValidation : AbstractValidator<StoreGroupLocalizationDto>
        {
            public StoreGroupLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Title)
                .NotEmpty();
            }
        }
    }
}
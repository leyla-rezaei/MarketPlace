using FluentValidation;
using MarketPlace.Dto.StoretSettings;

namespace MarketPlace.Application.Validations
{
    public class StoreValidation : AbstractValidator<StoreRequestDto>
    {
        public StoreValidation()
        {
            RuleFor(x => x.OwnerId)
               .NotNull();


            RuleFor(x => x.StoreIconId)
                .Must(id => id != Guid.Empty);

            RuleFor(x => x.Domain)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.StoreTypeId)
              .NotNull();

            RuleForEach(x => x.Localizations)
                .SetValidator(new StoreLocalizationValidation());
        }

        public class StoreLocalizationValidation : AbstractValidator<StoreLocalizationDto>
        {
            public StoreLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Title)
                .NotEmpty();
            }

        }
    }
}

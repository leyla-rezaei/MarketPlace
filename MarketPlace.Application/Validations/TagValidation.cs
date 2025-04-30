using FluentValidation;
using MarketPlace.Dto.Tags;

namespace MarketPlace.Application.Validations
{
    public class TagValidation : AbstractValidator<TagRequestDto>
    {
        public TagValidation()
        {
            RuleFor(x => x.IsApproved)
                .NotNull();
            RuleForEach(x => x.Localizations)
                .SetValidator(new TagLocalizationValidation());
        }
        public class TagLocalizationValidation : AbstractValidator<TagLocalizationDto>
        {
            public TagLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.TagName)
                .NotEmpty();
            }
        }
    }
}
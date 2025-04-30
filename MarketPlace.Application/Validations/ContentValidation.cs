using FluentValidation;
using MarketPlace.Dto.Contents;

namespace MarketPlace.Application.Validations
{
    public class ContentValidation : AbstractValidator<ContentRequestDto>
    {
        public ContentValidation()
        {
            RuleFor(x => x.ContentType)
                .IsInEnum().WithMessage("invalid content type.");

            RuleForEach(x => x.Localizations)
              .SetValidator(new ContentLocalizationValidation());
        }

        public class ContentLocalizationValidation : AbstractValidator<ContentLocalizationDto>
        {
            public ContentLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("title cannot be empty.");

                RuleFor(x => x.Body)
                    .NotEmpty().WithMessage("body cannot be empty.");
            }
        }
    }
}
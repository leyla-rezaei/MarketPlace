using FluentValidation;
using MarketPlace.Dto.Posts;

namespace MarketPlace.Application.Validations
{
    public class PostValidation : AbstractValidator<PostRequestDto>
    {
        public PostValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.Password)
                .MaximumLength(16);

            RuleFor(x => x.ParentId)
                .NotNull();

            RuleFor(x => x.WriterId)
                .NotNull();

            RuleFor(x => x.ThemeId)
                .NotNull();

            RuleForEach(x => x.Localizations)
                .SetValidator(new PostLocalizationValidation());
        }

        public class PostLocalizationValidation : AbstractValidator<PostLocalizationDto>
        {
            public PostLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Slug)
              .NotEmpty();

                RuleFor(x => x.Tags)
                    .NotEmpty();
            }
        }
    }
}

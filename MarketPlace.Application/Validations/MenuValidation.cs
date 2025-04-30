using FluentValidation;
using MarketPlace.Dto.SiteSettings;

namespace MarketPlace.Application.Validations
{
    public class MenuValidation : AbstractValidator<MenuRequestDto>
    {
        public MenuValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.MenuType)
                .NotNull();

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0)
                .WithMessage("order must be greater than or equal to 0.");

            RuleFor(x => x.MenuIconId)
                .NotNull();

            RuleFor(x => x.Url)
                .NotEmpty();

            RuleFor(x => x.PostId)
                .NotNull();

            RuleFor(x => x.PostCategoryId)
              .NotNull();

            RuleFor(x => x.ProductId)
               .NotNull();

            RuleForEach(x => x.Localizations)
           .SetValidator(new MenuLocalizationValidation());
        }

        public class MenuLocalizationValidation : AbstractValidator<MenuLocalizationDto>
        {
            public MenuLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Title)
                    .NotEmpty();
            }
        }
    }
}
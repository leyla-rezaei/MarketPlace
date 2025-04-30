using FluentValidation;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Validations
{
    public class BrandValidation : AbstractValidator<BrandRequestDto>
    {
        public BrandValidation()
        {
            RuleFor(x => x.BrandType)
                .NotNull();

            RuleFor(x => x.IsActive)
                .NotNull();

            RuleFor(x => x.RegistrationUrl)
                .NotNull();

            RuleFor(x => x.LogoId)
                .NotNull();

            RuleForEach(x => x.Localizations)
                .SetValidator(new BrandLocalizationValidation());

        }
        public class BrandLocalizationValidation : AbstractValidator<BrandLocalizationDto>
        {
            public BrandLocalizationValidation()
            { 
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.Name)
                    .NotNull()
                    .NotEmpty();

                RuleFor(x => x.Description)
                    .NotNull()
                    .NotEmpty();
            }
        }
    }
}
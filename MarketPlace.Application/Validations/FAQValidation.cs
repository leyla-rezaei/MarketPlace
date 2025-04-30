using FluentValidation;
using MarketPlace.Dto.StoretSettings;

namespace MarketPlace.Application.Validations
{
    public class FAQValidation : AbstractValidator<FAQRequestDto>
    {
        public FAQValidation()
        {
            RuleFor(x => x.StoreId)
                .NotNull();

            RuleFor(x => x.Order)
                .GreaterThan(0)
                .WithMessage("order must be greater than 0.");

            RuleForEach(x => x.Localizations)
            .SetValidator(new FAQLocalizationValidation());
        }

        public class FAQLocalizationValidation : AbstractValidator<FAQLocalizationDto>
        {
            public FAQLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty(); 

                RuleFor(x => x.Question)
                 .NotEmpty()
                 .WithMessage("question is required.")
                 .MaximumLength(255)
                 .WithMessage("question cannot exceed 255 characters.");

                RuleFor(x => x.Answer)
                    .NotEmpty()
                    .WithMessage("answer is required.")
                    .MaximumLength(1000)
                    .WithMessage("answer cannot exceed 1000 characters.");
            }
        }
    }
}
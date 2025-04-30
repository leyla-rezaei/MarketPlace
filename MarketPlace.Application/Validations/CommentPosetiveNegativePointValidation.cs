using FluentValidation;
using MarketPlace.Dto.Comments;
namespace MarketPlace.Application.Validations
{
    public class CommentPosetiveNegativePointValidation : AbstractValidator<CommentPosetiveNegativePointRequestDto>
    {
        public CommentPosetiveNegativePointValidation()
        {
            RuleFor(x => x.CommentId)
                .NotEmpty();


            RuleFor(x => x.PointComment)
                .IsInEnum().WithMessage("invalid point comment value.");

            RuleForEach(x => x.Localizations)
             .SetValidator(new CommentPosetiveNegativePointLocalizationValidation());
        }

        public class CommentPosetiveNegativePointLocalizationValidation : AbstractValidator<CommentPosetiveNegativePointLocalizationDto>
        {
            public CommentPosetiveNegativePointLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.CommentPoint)
                    .NotEmpty().WithMessage("comment point must not be empty.")
                    .MaximumLength(255).WithMessage("comment point cannot exceed 255 characters.");               
            }
        }

    }
}
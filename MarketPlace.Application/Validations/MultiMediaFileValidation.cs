using FluentValidation;
using MarketPlace.Dto.Media;

namespace MarketPlace.Application.Validations
{
    public class MultiMediaFileValidation : AbstractValidator<MultiMediaFileRequestDto>
    {
        public MultiMediaFileValidation()
        {
            RuleFor(x => x.MediaType)
                .NotNull();

            RuleFor(x => x.Url)
                .NotEmpty();

            RuleFor(x => x.UniqueUrl)
                .NotEmpty();

            RuleFor(x => x.FileSize)
                .GreaterThan(0);

          
            RuleFor(x => x.FileSizeType)
                .NotNull();

            RuleFor(x => x.Width)
                .GreaterThan(0);

            RuleFor(x => x.Height)
                .GreaterThan(0);

            RuleFor(x => x.MediaContentType)
                .NotNull();

            RuleForEach(x => x.Localizations)
          .SetValidator(new MultiMediaFileLocalizationValidation());
        }

        public class MultiMediaFileLocalizationValidation : AbstractValidator<MultiMediaFileLocalizationDto>
        {
            public MultiMediaFileLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.FileName)
              .NotEmpty();
            }
        }
    }
}

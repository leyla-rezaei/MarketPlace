using FluentValidation;
using MarketPlace.Dto.Products.ProductTypes;

namespace MarketPlace.Application.Validations
{
    public class DownloadableFileValidation : AbstractValidator<DownloadableFileRequestDto>
    {
        public DownloadableFileValidation()
        {
            RuleFor(x => x.ProductId)
             .NotNull();

            RuleFor(x => x.FileUrl)
                .NotEmpty()
                .MaximumLength(200)
                .Must(BeAValidUrl)
                .WithMessage("file url must be a valid url.");

            RuleForEach(x => x.Localizations)
              .SetValidator(new DownloadableFileLocalizationValidation());
        }

        private bool BeAValidUrl(string? url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public class DownloadableFileLocalizationValidation : AbstractValidator<DownloadableFileLocalizationDto> 
        {
            public DownloadableFileLocalizationValidation()
            {
                RuleFor(x => x.Key)
                    .NotEmpty();

                RuleFor(x => x.FileName)
                    .NotNull();
            }
        }

    }
}
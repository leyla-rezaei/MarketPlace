using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.MultiMediaFiles;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Media;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.MultiMediaFiles;

public class MultiMediaFileService : BaseService<MultiMediaFile, MultiMediaFileRequestDto, MultiMediaFileResponseDto>, IMultiMediaFileService
{
    private readonly IValidator<MultiMediaFileRequestDto> _multiMediaFileValidator;
    public MultiMediaFileService(IBaseRepository<MultiMediaFile> repository,
        IValidator<MultiMediaFileRequestDto> multiMediaFileValidator) : base(repository)
    {
        _multiMediaFileValidator = multiMediaFileValidator;
    }

    public async Task<SingleResponse<MultiMediaFile>> SaveMedia(IFormFile file, MultiMediaFileRequestDto input, CancellationToken cancellationToken)
    {
        var multiMediaFileValidation = _multiMediaFileValidator.Validate(input).GetAllErrorsString();
        if (multiMediaFileValidation.HasValue()) return (ResponseStatus.ValidationFailed, multiMediaFileValidation);

        var multimediaFile = new MultiMediaFile
        {
            FileSize = file.Length,
            MediaContentType = input.MediaContentType,
            Localizations = new List<MultiMediaFileLocalization>()
        };

        var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);
        foreach (var language in languages)
        {
            var localization = new MultiMediaFileLocalization { Key = language.Key };
            var multiMediaFileLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
            if (multiMediaFileLocalization is not null)
            {
                localization.FileName = multiMediaFileLocalization.FileName;
            }
            multimediaFile.Localizations.Add(localization);
        }
        await SaveMedia(file, input, cancellationToken);

        return ResponseStatus.Success;
    }

    public async Task<SingleResponse<MultiMediaFileResponseDto>> GetProductMediaFile(Guid productId, CancellationToken cancellationToken)
    {
        var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

        if (product is null) return ResponseStatus.NotFound;

        var multiMediaFiles = await base.GetAllAsNoTracking<ProductMultiMedia>()
            .Where(multiMediaFile => multiMediaFile.ProductId == productId)
            .Select(multiMediaFile => new MultiMediaFileResponseDto
            {
                FileSize = multiMediaFile.FileSize,
                FileSizeType = multiMediaFile.FileSizeType,
                Height = multiMediaFile.Height,
                Id = multiMediaFile.Id,
                MediaContentType = multiMediaFile.MediaContentType,
                MediaType = multiMediaFile.MediaType,
                UniqueUrl = multiMediaFile.UniqueUrl,
                Url = multiMediaFile.Url,
                Width = multiMediaFile.Width,
                Localization = multiMediaFile.Localizations
                .Select(x => new MultiMediaFileLocalizationDto { FileName = x.FileName, Key = x.Key }).ToList(),
            }).FirstOrDefaultAsync(cancellationToken);

        return multiMediaFiles;
    }

    public async Task<SingleResponse<bool>> Delete(MultiMediaFileRequestDto input)
    {
        var multimediaFile = GetAllAsNoTracking();

        if (multimediaFile == null)
        {
            return ResponseStatus.NotFound;
        }
        return ResponseStatus.Success;
    }
}
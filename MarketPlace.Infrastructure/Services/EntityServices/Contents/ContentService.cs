using FluentValidation;
using Mapster;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Contents;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Contents;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Enums.Content;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Contents;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Contents
{
    public class ContentService : BaseService<ProductContent, ContentRequestDto, ContentResponseDto>, IContentService
    {
        private readonly IValidator<ProductContentRequestDto> _productContentValidator;
        private readonly IBaseRepository<ProductContent> _repository;
        public ContentService(IBaseRepository<ProductContent> repository, IValidator<ProductContentRequestDto> productContentValidator) : base(repository)
        {
            _productContentValidator = productContentValidator;
            _repository = repository;
        }

        public async Task<SingleResponse<ProductContent>> CreateProductContent(ProductContentRequestDto input, CancellationToken cancellationToken)
        {
            //check product content validation then create it
            var productContentValidation = _productContentValidator.Validate(input).GetAllErrorsString();
            if (productContentValidation.HasValue()) return (ResponseStatus.ValidationFailed, productContentValidation);

            var content = input.Adapt<ProductContent>();
            var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);
            foreach (var language in languages)
            {
                var localization = new ProductContentLocalization { Key = language.Key };
                var productContentLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();

                if (productContentLocalization is not null)
                {
                    var contentCheckingStatus = await IsContentAllowedGenerally(new()
                    {
                        productContentLocalization.Body,
                        productContentLocalization.Title,
                        productContentLocalization.ShortDescription
                    }, true, cancellationToken);

                    if (contentCheckingStatus.Status == ResponseStatus.ContentNotAllowed) return ResponseStatus.ContentNotAllowed;

                    content.ContentAllowingStatus = contentCheckingStatus.Status == ResponseStatus.Success
                        ? ContentAllowingStatus.Allowed
                        : ContentAllowingStatus.Pending;
                }
                content.Localizations.Add(localization);
            }
            await Create<ProductContent, ProductContentRequestDto>(input, cancellationToken);

            //TODO Send notification to admin to check the content and change AllowingStatus 
            //TODO Send notification to store owner to notif him

            return ResponseStatus.Success;
        }

        public async Task<JustResponse> IsContentAllowedGenerally(List<string> contents, bool checkHoldQueueWords = false, CancellationToken cancellationToken = default)
        {
            var mainSettings = await GetAllAsNoTracking<MainBusinessSetting>().FirstAsync(cancellationToken);
            var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);


            var disallowedWords = mainSettings.DisallowedCommentKeys
                .Split("|", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

            foreach (var c in contents)
            {
                if (disallowedWords.Any(x => c.Contains(x))) return ResponseStatus.ContentNotAllowed;
            }

            if (checkHoldQueueWords)
            {
                var onHoldWords = mainSettings.HoldQueueWords.Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim());

                foreach (var c in contents)
                {
                    if (onHoldWords.Any(x => c.Contains(x))) return ResponseStatus.ContentNeedReview;
                }
            }

            return ResponseStatus.Success;
        }

        private async Task<bool> IsContentInPendingListAsync(Guid storeId, string content, CancellationToken cancellationToken)
        {
            var mainSettings = await GetAll<MainBusinessSetting>().FirstAsync(cancellationToken);


            var disallowedWords = mainSettings.DisallowedCommentKeys.Split("|", StringSplitOptions.RemoveEmptyEntries)
         .Select(x => x.Trim());

            if (disallowedWords.Any(x => content.Contains(x)))
                return false;
            return true;
        }

        public async Task<SingleResponse<ContentResponseDto>> GetContentByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;

            var content = await base.GetAllAsNoTracking<ProductContent>()
           .Where(content => content.ProductId == productId)
           .Select(content => new ContentResponseDto
           {
               ContentAllowingStatus = content.ContentAllowingStatus,
               ContentType = content.ContentType,
               Id = content.Id,
               Order = content.Order,
               Localizations = content.Localizations
               .Select(x => new ContentLocalizationDto
               {
                   Body = x.Body,
                   Title = x.Title,
                   Key = x.Key
               }).ToList(),

           }).FirstOrDefaultAsync(cancellationToken);
            return content;
        }

        public async Task<SingleResponse<ProductContent>> Update(Guid id, Guid productId, ProductContentRequestDto input, string languageKey, CancellationToken cancellationToken)
        {
            var productContent = await GetAll<ProductContent>()
                .Where(x => x.Id == id && x.ProductId == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (productContent is null) return ResponseStatus.NotFound;

            var resultExist = await GetAllAsNoTracking()
           .Where(x => x.ProductId == input.ProductId && x.Id != id).AnyAsync(cancellationToken);

            productContent.ContentType = input.ContentType;
            productContent.Order = input.Order;
            productContent.ProductId = productId;
            productContent.Localizations = new List<ProductContentLocalization>();

            var oldLoacalizations = await GetAll<ProductContentLocalization>().Where(x => x.ContentId == id).ToListAsync(cancellationToken);
            await Delete(oldLoacalizations, cancellationToken);

            foreach (var localizationDto in input.Localizations)
            {
                var localization = new ProductContentLocalization
                {
                    Key = localizationDto.Key,
                    Body = localizationDto.Body,
                    Title = localizationDto.Title,
                    ShortDescription = localizationDto.ShortDescription
                };
                productContent.Localizations.Add(localization);
            }

            var productContentLocalization = input.Localizations.Where(x => x.Key == languageKey).FirstOrDefault();
            if (productContentLocalization is not null)
            {
                var contentCheckingStatus = await IsContentAllowedGenerally(new()
                {
                    productContentLocalization.Body,
                    productContentLocalization.Title,
                    productContentLocalization.ShortDescription
                }, true, cancellationToken);

                if (contentCheckingStatus.Status != ResponseStatus.Success) return contentCheckingStatus.Status;
            }

            await Update(productContent, cancellationToken);

            return ResponseStatus.Success;
        }
    }
}
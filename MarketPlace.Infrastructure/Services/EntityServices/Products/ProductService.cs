using FluentValidation;
using Mapster;
using MarketPlace.Dto.Products;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Contents;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Application.Services.EntityServices.Tags;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Domain.Entities.Tags;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Enums.Product;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;
using MarketPlace.Application.Services.EntityServices.Categories;
using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Dto.Products.ProductTypes;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Contents;
using static MarketPlace.Dto.Products.ProductRequestDto;




namespace MarketPlace.Infrastructure.Services.EntityServices.Products;

public class ProductService : BaseService<Product, ProductRequestDto, ProductResponseDto>, IProductService
{
    private readonly IBaseRepository<Product> _repository;
    private readonly IContentService _contentService;
    private readonly ICategoryService _categoryService;
    private readonly ITagService _tagService;
    private readonly IValidator<ProductRequestDto> _productValidator;

    public ProductService(IBaseRepository<Product> repository,
        IContentService contentService,
        ICategoryService categoryService,
        ITagService tagService,
        IValidator<ProductRequestDto> productValidator)
            : base(repository)
    {
        _repository = repository;
        _contentService = contentService;
        _categoryService = categoryService;
        _tagService = tagService;
        _productValidator = productValidator;
    }

    public async Task<SingleResponse<Product>> CreateProduct(CreateProductRequestDto input, CancellationToken cancellationToken)
    {
        //check product validation then create it
        var productValidation = _productValidator.Validate(input.ProductRequestDto).GetAllErrorsString();
        if (productValidation.HasValue()) return (ResponseStatus.ValidationFailed, productValidation);

        var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);
        foreach (var language in languages)
        {
            var localization = new ProductContentLocalization { Key = language.Key };
            var productContentLocalization = input.ProductContentRequestDto.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
            if (productContentLocalization is not null)
            {
                //check the content is allowed 
                var isContentAllowed = await _contentService.IsContentAllowedGenerally(new() {
                productContentLocalization.Title,
                productContentLocalization.ShortDescription,
                productContentLocalization.Body
                }, cancellationToken: cancellationToken);

                if (isContentAllowed.Status != ResponseStatus.Success) return isContentAllowed.Status;
            }
        }

        //if product is download must have download file list
        if (input.ProductRequestDto.ProductType == ProductType.Downloadable &&
        input.DownloadableFileRequestDto.Count == 0)
            return ResponseStatus.DownloadableFileRequired;

        //check if categories are availabel 
        var isCategoriesAvailable = await _categoryService.CheckCategoryIds(input.CategoryIds, cancellationToken);
        if (isCategoriesAvailable.Status != ResponseStatus.Success) return ResponseStatus.CategoryNotAvailable;

        //check if tags are availabel 
        var isTagsAvailable = _tagService.CheckTagIds(input.TagIds).Status;
        if (isTagsAvailable != ResponseStatus.Success) return ResponseStatus.TagNotAvailable;


        //check if the brand is exist
        var isBrandExist = await GetAllAsNoTracking<Brand>().Where(x => x.Id == input.ProductRequestDto.BrandId).AnyAsync(cancellationToken);
        if (!isBrandExist) return ResponseStatus.NotFound;

        //check if tags exist for product
        var isTagExist = await GetAll<Tag>().Where(x => input.TagIds.Contains(x.Id)).AnyAsync(cancellationToken);
        if (!isTagExist) return ResponseStatus.NotFound;

        //check if the product exists in the specified categories
        var isCategoryExist = await GetAll<Category>().Where(x => input.CategoryIds.Contains(x.Id)).AnyAsync(cancellationToken);
        if (!isCategoryExist) return ResponseStatus.NotFound;

        // TODO check attributes 

        var product = await CreateProduct(input.ProductRequestDto, cancellationToken);

        //save the price
        await Create<Price, Price>(new Price
        {
            ProductId = product.Id,
            SalePrice = input.SalePrice
        }, cancellationToken);

        //save the content

        input.ProductContentRequestDto.ProductId = product.Id;
        await _contentService.CreateProductContent(input.ProductContentRequestDto, cancellationToken);

        // add tag to product
        var productTags = input.TagIds.Select(tagId => new ProductTag
        {
            ProductId = product.Id,
            TagId = tagId
        }).ToList();
        await CreateRange(productTags, cancellationToken);

        //add product to category
        var productCategories = input.CategoryIds.Select(categoryId => new ProductCategory
        {
            ProductId = product.Id,
            CategoryId = categoryId
        }).ToList();
        await CreateRange(productCategories, cancellationToken);

        return ResponseStatus.Success;
    }

    private async Task<JustResponse> AddTagToProduct(Guid userId, Guid productId, List<Guid> tagIds)
    {
        var product = GetAllAsNoTracking();

        if (product == null)
            return ResponseStatus.NotFound;

        foreach (var tagId in tagIds)
        {
            var productTag = new ProductTag
            {
                ProductId = productId,
                TagId = tagId
            };
            await AddTagToProduct(userId, productId, tagIds);
        }
        return ResponseStatus.Success;
    }

    private async Task<JustResponse> AddProductToCategory(Guid userId, Guid productId, Dictionary<string, string> CategoryAttributeId_value)
    {
        if (userId == Guid.Empty || productId == Guid.Empty || CategoryAttributeId_value == null || !CategoryAttributeId_value.Any())
        {
            return ResponseStatus.NotAllowed;

        }
        await AddProductToCategory(userId, productId, CategoryAttributeId_value);
        return ResponseStatus.Success;
    }

    private async Task<JustResponse> AddDownloadableFilesToProduct(Guid userId, Guid productId, List<DownloadableFileRequestDto> downloadableFilesInput, CancellationToken cancellationToken)
    {
        var product = GetAllAsNoTracking();
        if (product == null)
            return ResponseStatus.NotFound;

        foreach (var fileInput in downloadableFilesInput)
        {
            var downloadableFile = new DownloadableFile
            {
                FileUrl = fileInput.FileUrl,
                Localizations = new List<DownloadableFileLocalization>()
            };
        }
        var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);
        foreach (var language in languages)
        {
            var localization = new DownloadableFileLocalization { Key = language.Key };
            var downloadableFileLocalization = downloadableFilesInput.Adapt<DownloadableFile>().Localizations
                .Where(x => x.Key == language.Key).FirstOrDefault();
            if (downloadableFileLocalization is not null)
            {
                localization.FileName = downloadableFileLocalization.FileName;
            }
            downloadableFilesInput.Adapt<DownloadableFile>().Localizations.Add(localization);
        }
        await AddDownloadableFilesToProduct(userId, productId, downloadableFilesInput, cancellationToken);

        return ResponseStatus.Success;
    }

    private async Task<Product> CreateProduct(ProductRequestDto input, CancellationToken cancellationToken)
    {
        var generalCode = GenerateUniqueGeneralCode();

        var product = input.Adapt<Product>();

        if (!product.IsSchedulingPublish && product.PublishStatus != PublishStatus.Draft)
            product.PublishStatus = PublishStatus.Scheduled;
        else if (product.PublishStatus == PublishStatus.Draft)
            product.PublishStatus = PublishStatus.Published;

        product.GeneralCode = generalCode;
        product.CommentCount = 0;
        product.CommentCount = 0;
        product.ViewCount = 0;

        var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);

        foreach (var language in languages)
        {
            var isLocalizationExist = product.Localizations.FirstOrDefault(x => x.Key == language.Key);
            if (isLocalizationExist == null)
            {
                isLocalizationExist = new ProductLocalization { Key = language.Key };
                product.Localizations.Add(isLocalizationExist);
            }

            var productLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
            if (productLocalization is not null)
            {
                isLocalizationExist.PurchaseNote = productLocalization.PurchaseNote;
                isLocalizationExist.PackingDescription = productLocalization.PackingDescription;
            }
        }

        return await _repository.Create(product, cancellationToken);
    }

    private string GenerateUniqueGeneralCode()
    {
        Random random = new Random();
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        char[] digits = Enumerable.Range(0, 10)
            .Select(_ => (char)(random.Next(10) + '0'))
            .ToArray();

        char[] randomLetters = Enumerable.Range(0, 4)
            .Select(_ => letters[random.Next(letters.Length)])
            .ToArray();

        return new string(randomLetters) + new string(digits);
    }
    public async Task<SingleResponse<ProductResponseDto>> GetProduct(Guid productId, CancellationToken cancellationToken)
    {
        var products = await base.GetAllAsNoTracking()
         .Where(product => product.Id == productId)
         .Select(product => new ProductResponseDto
         {
             Id = product.Id,
             Brand = product.Brand,
             AllowBackordersStatus = product.AllowBackordersStatus,
             CatalogVisibility = product.CatalogVisibility,
             CommentCount = product.CommentCount,
             GeneralCode = product.GeneralCode,
             IsCommentsAllowed = product.IsCommentsAllowed,
             IsInstallmentEnabled = product.IsInstallmentEnabled,
             IsManageStock = product.IsManageStock,
             IsOrginalProduct = product.IsOrginalProduct,
             IsSchedulingPublish = product.IsSchedulingPublish,
             PackingHeight = product.PackingHeight,
             LowStockThreshold = product.LowStockThreshold,
             MenuOrder = product.MenuOrder,
             PackingLength = product.PackingLength,
             PackingWidth = product.PackingWidth,
             Password = product.Password,
             ProductHeight = product.ProductHeight,
             ProductLength = product.ProductLength,
             ProductType = product.ProductType,
             ProductWidth = product.ProductWidth,
             PublishOn = product.PublishOn,
             PublishStatus = product.PublishStatus,
             SelledQuantity = product.SelledQuantity,
             SerialNumber = product.SerialNumber,
             ShippingClass = product.ShippingClass,
             StockQuantity = product.StockQuantity,
             StockStatus = product.StockStatus,
             Store = product.Store,
             TotalRate = product.TotalRate,
             ViewCount = product.ViewCount,
             Visibility = product.Visibility,
             ProductSellingUnit = product.ProductSellingUnit,
             Localizations = product.Localizations
             .Select(x => new ProductLocalizationDto
             {
                 Key = x.Key,
                 PackingDescription = x.PackingDescription,
                 PurchaseNote = x.PurchaseNote
             }).ToList(),

         }).FirstOrDefaultAsync(cancellationToken);

        if (products == null) return ResponseStatus.NotFound;

        return products;
    }
}
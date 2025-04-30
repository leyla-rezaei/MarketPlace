using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Products;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Products
{
    public class BrandService : BaseService<Brand, BrandRequestDto, BrandResponseDto>, IBrandService
    {
        private readonly IBaseRepository<Brand> _repository;
        private readonly IValidator<BrandRequestDto> _brandValidator;
        private readonly IProductService _productService;

        public BrandService(IBaseRepository<Brand> repository, IValidator<BrandRequestDto> brandValidator, IProductService productService) : base(repository)
        {
            _repository = repository;
            _brandValidator = brandValidator;
            _productService = productService;
        }

        public async Task<SingleResponse<Brand>> CreateBrand(BrandRequestDto input, CancellationToken cancellationToken)
        {
            var brandValidation = _brandValidator.Validate(input).GetAllErrorsString();
            if (brandValidation.HasValue()) return (ResponseStatus.ValidationFailed, brandValidation);

            var brand = new Brand
            {
                IsApproved = input.IsApproved,
                IsActive = input.IsActive,
                BrandType = input.BrandType,
                LogoId = input.LogoId,
                Localizations = new List<BrandLocalization>()
            };

            var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);

            foreach (var language in languages)
            {
                var localization = new BrandLocalization { Key = language.Key };
                var brandLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
                if (brandLocalization is not null)
                {
                    localization.Name = brandLocalization.Name;
                    localization.Description = brandLocalization.Description;
                }
                brand.Localizations.Add(localization);
            }
            await _repository.Create(brand, cancellationToken);
            return ResponseStatus.Success;
        }

        public async Task<SingleResponse<BrandResponseDto>> GetBrandByProductId(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Include(x => x.Brand)
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;
            if (product.Brand is null) return ResponseStatus.NotFound;

            var brandResponseDto = new BrandResponseDto
            {
                Id = product.Brand.Id,
                LogoId = product.Brand.LogoId,
                BrandType = product.Brand.BrandType,
                IsActive = product.Brand.IsActive,
                IsApproved = product.Brand.IsApproved,
                RegistrationUrl = product.Brand.RegistrationUrl,
                Localizations = product.Brand?.Localizations?
                .Select(x => new BrandLocalizationDto()
                {
                    Description = x.Description,
                    Name = x.Name,
                    Key = x.Key
                }).ToList(),
            };

            return brandResponseDto;
        }

        public async Task<ListResponse<BrandSummaryResponseDto>> GetBrands(string languageKey, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetAllAsNoTracking<Brand>()
                .Select(brand => new BrandSummaryResponseDto
                {
                    Id = brand.Id,
                    BrandType = brand.BrandType,
                    IsActive = brand.IsActive,
                    RegistrationUrl = brand.RegistrationUrl,
                    IsApproved = brand.IsApproved,
                    LogoId = brand.LogoId,
                    Name = brand.Localizations.Where(x => x.Key == languageKey).FirstOrDefault().Name,
                    Description = brand.Localizations.Where(x => x.Key == languageKey).FirstOrDefault().Description,
                })
                .ToListAsync(cancellationToken);

            return brands;
        }

        public async Task<SingleResponse<Brand>> UpdateBrand(Guid id, BrandRequestDto input, CancellationToken cancellationToken)
        {
            var brandValidation = _brandValidator.Validate(input).GetAllErrorsString();
            if (brandValidation.HasValue()) return (ResponseStatus.ValidationFailed, brandValidation);

            var brand = await GetAll().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (brand is null) return ResponseStatus.NotFound;

            var resultExist = await GetAllAsNoTracking()
             .Where(x => x.RegistrationUrl == input.RegistrationUrl && x.Id != id).AnyAsync(cancellationToken);

            brand.IsApproved = input.IsApproved;
            brand.IsActive = input.IsActive;
            brand.BrandType = input.BrandType;
            brand.LogoId = input.LogoId;
            brand.Localizations = new List<BrandLocalization>();

            var oldLocalization = await GetAll<BrandLocalization>().Where(x => x.BrandId == id).ToListAsync(cancellationToken);
            await Delete(oldLocalization, cancellationToken);

            var languages = await GetAllAsNoTracking<Language>().ToListAsync(cancellationToken);

            foreach (var language in languages)
            {
                var localization = new BrandLocalization { Key = language.Key };
                var brandLocalization = input.Localizations.Where(x => x.Key == language.Key).FirstOrDefault();
                if (brandLocalization is not null)
                {
                    localization.Name = brandLocalization.Name;
                    localization.Description = brandLocalization.Description;
                }
                brand.Localizations.Add(localization);
            }
            await Update(brand, cancellationToken);

            return ResponseStatus.Success;
        }

        public async Task<SingleResponse<bool>> DeleteBrand(Guid brandId, BrandRequestDto input, bool IsActive, CancellationToken cancellationToken)
        {
            var isBrandExist = await GetAll().AnyAsync(x => x.Id == brandId, cancellationToken);

            if (!isBrandExist) return ResponseStatus.NotFound;

            var isUsedByOtherEntities = await GetAll<Product>().AnyAsync(x => x.BrandId == brandId, cancellationToken);

            if (isUsedByOtherEntities)
            {
                IsActive = false;

                await Update(brandId, input, cancellationToken);

                return new SingleResponse<bool> { Status = ResponseStatus.Success, Message = "brand is used by product. deactivated successfully." };
            }
            else 
            {
                var localization = await GetAll<BrandLocalization>().Where(x => x.BrandId == brandId).ToListAsync(cancellationToken);
                 await Delete(localization, cancellationToken);
                
                await Delete(brandId, cancellationToken);

                return new SingleResponse<bool> { Status = ResponseStatus.Success, Message = "brand deleted successfully." };
            }
           
        }
    }
}

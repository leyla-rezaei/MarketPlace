using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Shippings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Shippings
{
    public class ShippingClassService : BaseService<ShippingClass, ShippingClassRequestDto, ShippingClassResponseDto>, IShippingClassService
    {
        private readonly IValidator<ShippingClassRequestDto> _shippingClassValidator;
        private readonly IProductService _productService;
        public ShippingClassService(IBaseRepository<ShippingClass> repository,
            IValidator<ShippingClassRequestDto> shippingClassValidator,
            IProductService productService) : base(repository)
        {
            _shippingClassValidator = shippingClassValidator;
            _productService = productService;
        }

        public async Task<SingleResponse<ShippingClass>> CreateShippingClass(ShippingClassRequestDto input, CancellationToken cancellationToken)
        {
            var ShippingClassValidation = _shippingClassValidator.Validate(input).GetAllErrorsString();
            if (ShippingClassValidation.HasValue()) return (ResponseStatus.ValidationFailed, ShippingClassValidation);

            var isShippingClassExist = await GetAllAsNoTracking<Store>().AnyAsync(x => x.Id == input.StoreId, cancellationToken);

            if (!isShippingClassExist) return ResponseStatus.NotFound;

            return await CreateShippingClass(input, cancellationToken);
        }

        public async Task<SingleResponse<ShippingClassResponseDto>> GetShippingClassesById(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;

            var shippingClass = new ShippingClassResponseDto
            {
                Id = product.ShippingClass.Id,
                ProductCount = product.ShippingClass.ProductCount,
                Store = product.ShippingClass.Store,

                Localizations = product.ShippingClass.Localizations
                .Select(x => new ShippingClassLocalizationDto
                {
                    Description = x.Description, 
                    Slug = x.Slug
                    , Key = x.Key 
                }).ToList(),
            };

            return shippingClass;
        }
    }
}

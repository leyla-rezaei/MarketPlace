using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Shippings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Shippings
{
    public class ShippingMethodService : BaseService<ShippingMethod, ShippingMethodRequestDto, ShippingMethodResponseDto>, IShippingMethodService
    {
        private readonly IValidator<ShippingMethodRequestDto> _shippingMethodValidator;
        public ShippingMethodService(IBaseRepository<ShippingMethod> repository,
            IValidator<ShippingMethodRequestDto> shippingMethodValidator) : base(repository)
        {
            _shippingMethodValidator = shippingMethodValidator;
        }

        public async Task<SingleResponse<ShippingMethod>> CreateShippingMethod(ShippingMethodRequestDto input, CancellationToken cancellationToken)
        {
            var shippingMethodValidation = _shippingMethodValidator.Validate(input).GetAllErrorsString();
            if (shippingMethodValidation.HasValue()) return (ResponseStatus.ValidationFailed, shippingMethodValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateShippingMethod(input, cancellationToken);
        }
    }
}

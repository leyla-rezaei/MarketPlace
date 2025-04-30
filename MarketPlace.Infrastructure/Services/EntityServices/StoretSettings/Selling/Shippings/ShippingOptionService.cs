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
    public class ShippingOptionService : BaseService<ShippingOption, ShippingOptionRequestDto, ShippingOptionResponseDto>, IShippingOptionService
    {
        private readonly IValidator<ShippingOptionRequestDto> _shippingOptionValidator;
        public ShippingOptionService(IBaseRepository<ShippingOption> repository,
            IValidator<ShippingOptionRequestDto> shippingOptionValidator) : base(repository)
        {
            _shippingOptionValidator = shippingOptionValidator;
        }

        public async Task<SingleResponse<ShippingOption>> CreateShippingOption(ShippingOptionRequestDto input, CancellationToken cancellationToken)
        {
            var shippingOptionValidation = _shippingOptionValidator.Validate(input).GetAllErrorsString();
            if (shippingOptionValidation.HasValue()) return (ResponseStatus.ValidationFailed, shippingOptionValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateShippingOption(input, cancellationToken);
        }
    }
}

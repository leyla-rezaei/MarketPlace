using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using MarketPlace.StoretSettings.Settings;
using FluentValidation;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreAddressService : BaseService<StoreAddress, StoreAddressRequestDto, StoreAddressResponseDto>, IStoreAddressService
    {
        private readonly IValidator<StoreAddressRequestDto> _storeAddressValidator;
        public StoreAddressService(IBaseRepository<StoreAddress> repository,
            IValidator<StoreAddressRequestDto> storeAddressValidator) : base(repository)
        {
            _storeAddressValidator = storeAddressValidator;
        }

        public  async Task<SingleResponse<StoreAddress>> CreateStoreAddress(StoreAddressRequestDto input, CancellationToken cancellationToken)
        {
            var storeAddressValidation = _storeAddressValidator.Validate(input).GetAllErrorsString();
            if (storeAddressValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeAddressValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isCityExist = await GetAllAsNoTracking<City>().Where(x => x.Id == input.CityId).AnyAsync(cancellationToken);
            if (!isCityExist) return ResponseStatus.NotFound;

            return await CreateStoreAddress(input, cancellationToken);
        }
    }
}
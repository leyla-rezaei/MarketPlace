using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Setting;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Selling.Setting;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Setting
{
    public class StoreGeneralSellingSettingsService : BaseService<StoreGeneralSellingSettings, StoreGeneralSellingSettingsRequestDto, StoreGeneralSellingSettingsResponseDto>, IStoreGeneralSellingSettingsService
    {
        private readonly IValidator<StoreGeneralSellingSettingsRequestDto> _storeGeneralSellingSettingsValidator;
        public StoreGeneralSellingSettingsService(IBaseRepository<StoreGeneralSellingSettings> repository,
            IValidator<StoreGeneralSellingSettingsRequestDto> storeGeneralSellingSettingsValidator) : base(repository)
        {
            _storeGeneralSellingSettingsValidator = storeGeneralSellingSettingsValidator;
        }
        public async Task<SingleResponse<StoreGeneralSellingSettings>> CreateStoreGeneralSellingSettings(StoreGeneralSellingSettingsRequestDto input, CancellationToken cancellationToken)
        {
            var storeGeneralSellingSettingsValidation = _storeGeneralSellingSettingsValidator.Validate(input).GetAllErrorsString();
            if (storeGeneralSellingSettingsValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeGeneralSellingSettingsValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isCurrencyExist = await GetAllAsNoTracking<Currency>().Where(x => x.Id == input.CurrencyId).AnyAsync(cancellationToken);
            if (!isCurrencyExist) return ResponseStatus.NotFound;

            return await CreateStoreGeneralSellingSettings(input, cancellationToken);
        }
    }
}

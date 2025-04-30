using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Setting;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Selling.Setting;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.Setting
{
    public class StoreInventorySettingService : BaseService<StoreInventorySetting, StoreInventorySettingRequestDto, StoreInventorySettingResponseDto>, IStoreInventorySettingService
    {
        private readonly IValidator<StoreInventorySettingRequestDto> _storeInventorySettingValidator;
        public StoreInventorySettingService(IBaseRepository<StoreInventorySetting> repository,
            IValidator<StoreInventorySettingRequestDto> storeInventorySettingValidator) : base(repository)
        {
            _storeInventorySettingValidator = storeInventorySettingValidator;
        }

        public  async Task<SingleResponse<StoreInventorySetting>> CreateStoreInventorySetting(StoreInventorySettingRequestDto input, CancellationToken cancellationToken)
        {
            var storeInventorySettingValidation = _storeInventorySettingValidator.Validate(input).GetAllErrorsString();
            if (storeInventorySettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeInventorySettingValidation);

            var isUserExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isUserExist) return ResponseStatus.NotFound;

            return await CreateStoreInventorySetting(input, cancellationToken);
        }
    }
}

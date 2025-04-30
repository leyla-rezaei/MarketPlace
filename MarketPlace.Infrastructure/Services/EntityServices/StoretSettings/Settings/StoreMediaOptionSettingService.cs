using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreMediaOptionSettingService : BaseService<StoreMediaOptionSetting, StoreMediaOptionSettingRequestDto, StoreMediaOptionSettingResponseDto>, IStoreMediaOptionSettingService
    {
        private readonly IValidator<StoreMediaOptionSettingRequestDto> _storeMediaOptionSettingValidator;
        public StoreMediaOptionSettingService(IBaseRepository<StoreMediaOptionSetting> repository,
            IValidator<StoreMediaOptionSettingRequestDto> storeMediaOptionSettingValidator) : base(repository)
        {
            _storeMediaOptionSettingValidator = storeMediaOptionSettingValidator;
        }

        public async Task<SingleResponse<StoreMediaOptionSetting>> CreateStoreMediaOptionSetting(StoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken)
        {
            var StoreMediaOptionSettingValidation = _storeMediaOptionSettingValidator.Validate(input).GetAllErrorsString();
            if (StoreMediaOptionSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, StoreMediaOptionSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateStoreMediaOptionSetting(input, cancellationToken);
        }
    }
}

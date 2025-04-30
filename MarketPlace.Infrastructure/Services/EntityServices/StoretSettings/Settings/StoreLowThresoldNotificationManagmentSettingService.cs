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
    public class StoreLowThresoldNotificationManagmentSettingService : BaseService<StoreLowThresoldNotificationManagmentSetting, StoreLowThresoldNotificationManagmentSettingRequestDto, StoreLowThresoldNotificationManagmentSettingResponseDto>,
        IStoreLowThresoldNotificationManagmentSettingService
    {
        private readonly IValidator<StoreLowThresoldNotificationManagmentSettingRequestDto> _storeLowThresoldNotificationManagmentSettingValidator;
        public StoreLowThresoldNotificationManagmentSettingService(IBaseRepository<StoreLowThresoldNotificationManagmentSetting> repository,
            IValidator<StoreLowThresoldNotificationManagmentSettingRequestDto> storeLowThresoldNotificationManagmentSettingValidator) : base(repository)
        {
            _storeLowThresoldNotificationManagmentSettingValidator = storeLowThresoldNotificationManagmentSettingValidator;
        }

        public async Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> CreateStoreLowThresoldNotificationManagmentSetting(StoreLowThresoldNotificationManagmentSettingRequestDto input,
            CancellationToken cancellationToken)
        {
            var storeLowThresoldNotificationManagmentSettingValidation = _storeLowThresoldNotificationManagmentSettingValidator
                .Validate(input).GetAllErrorsString();
            if (storeLowThresoldNotificationManagmentSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeLowThresoldNotificationManagmentSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateStoreLowThresoldNotificationManagmentSetting(input, cancellationToken);
        }
    }
}
using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Settings
{
    public interface IStoreLowThresoldNotificationManagmentSettingService
    {
        Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> CreateStoreLowThresoldNotificationManagmentSetting(StoreLowThresoldNotificationManagmentSettingRequestDto input, CancellationToken cancellationToken);
    }
}

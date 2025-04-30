using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Settings
{
    public interface IStoreGeneralSettingService
    {
        Task<SingleResponse<StoreGeneralSetting>> CreateStoreGeneralSetting(StoreGeneralSettingRequestDto input, CancellationToken cancellationToken);
    }
}

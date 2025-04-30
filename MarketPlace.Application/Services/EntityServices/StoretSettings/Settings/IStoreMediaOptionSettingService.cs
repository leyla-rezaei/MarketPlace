using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Settings
{
    public interface IStoreMediaOptionSettingService
    {
        Task<SingleResponse<StoreMediaOptionSetting>> CreateStoreMediaOptionSetting(StoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken);
    }
}

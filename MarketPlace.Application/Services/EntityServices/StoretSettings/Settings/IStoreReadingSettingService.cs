using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Settings
{
    public interface IStoreReadingSettingService
    {
        Task<SingleResponse<StoreReadingSetting>> CreateStoreReadingSetting(StoreReadingSettingRequestDto input, CancellationToken cancellationToken);
    }
}

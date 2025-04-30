using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using MarketPlace.Dto.StoretSettings.Selling.Setting;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Setting
{
    public interface IStoreInventorySettingService
    {
        Task<SingleResponse<StoreInventorySetting>> CreateStoreInventorySetting(StoreInventorySettingRequestDto input, CancellationToken cancellationToken);
    }
}

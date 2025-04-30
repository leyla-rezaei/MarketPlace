using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;


namespace MarketPlace.Application.Services.EntityServices.StoretSettings.Settings
{
    public interface IStoreDiscussionSettingService 
    {
        Task<SingleResponse<StoreDiscussionSetting>> CreateStoreDiscussionSetting(StoreDiscussionSettingRequestDto input, CancellationToken cancellationToken);
    }
}
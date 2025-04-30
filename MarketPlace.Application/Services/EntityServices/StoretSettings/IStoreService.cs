using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.StoretSettings.Settings;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings;

public interface IStoreService : IBaseService<Store, StoreRequestDto, StoreResponseDto>
{
    Task<SingleResponse<Store>> CreateStore(IFormFile file, CreateStoreRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<Store>> ChangeStoreType(Guid userId, Guid storeId, StoreType storeType, CancellationToken cancellationToken);
    Task<SingleResponse<Store>> ChangeStoreActivationStatus(Guid createdById, StoreActivationStatusRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreAdmin>> AddStoreAdmin(Guid userId, AddStoreAdminRequestDto input, CancellationToken cancellationToken);
    Task<JustResponse> RemoveAdminFromStore(AddStoreAdminRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreGeneralSetting>> GetStoreGenerallSettings(Guid userId, Guid storeId, CancellationToken cancellationToken);
    Task<SingleResponse<bool>> IsDomainAvailable(string domainName, CancellationToken cancellationToken);
    Task<ListResponse<StoreAddress>> CreateStoreAddress(Guid userId, Guid storeId, List<StoreAddressRequestDto> addressInput, CancellationToken cancellationToken);
    Task<SingleResponse<StoreAddress>> UpdateStoreAddress(Guid userId, Guid addressId, StoreAddressRequestDto input, CancellationToken cancellationToken);
    ListResponse<StoreAddress> GetStoreAddress(Guid storeId);
    Task<SingleResponse<StoreDiscussionSetting>> CreateStoreDiscussionSetting(Guid userId, StoreDiscussionSettingRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreDiscussionSetting>> GetStoreDiscussionSetting(Guid storeId, CancellationToken cancellationToken);
    Task<SingleResponse<StoreMediaOptionSetting>> CreateStoreMediaOptions(Guid userId, StoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreMediaOptionSetting>> GetStoreMediaOptions(Guid storeId, CancellationToken cancellationToken);
    Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> CreateStoreLowThresoldNotificationManagment(
        Guid userId, StoreLowThresoldNotificationManagmentSettingRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> GetStoreLowThresoldNotificationManagment(Guid storeId, CancellationToken cancellationToken);
    Task<SingleResponse<StoreReadingSetting>> CreateStoreReadingSettings(Guid userId, StoreReadingSettingRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreReadingSetting>> GetStoreReadingSettings(Guid storeId, CancellationToken cancellationToken);
    Task<SingleResponse<StoreGeneralSetting>> UpdateStoreGenerallSettings(Guid userId, StoreGeneralSettingRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreGeneralSetting>> CreateStoreGenerallSettings(Guid userId, StoreGeneralSettingRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<StoreResponseDto>> GetStoreProductId(Guid productId, CancellationToken cancellationToken);
}

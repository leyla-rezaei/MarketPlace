using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Enums.Account;
using MarketPlace.Dto.StoretSettings;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.StoretSettings.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlace.Api.Controllers.StoretSettings;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly IStoreService _service;

    public StoreController(IStoreService service)
    {
        _service = service;
    }

    [HttpPost("[action]")]
    [Authorize]
    public async Task<SingleResponse<Store>> CreateStore(IFormFile file, CreateStoreRequestDto input, CancellationToken cancellationToken)
    {

        return await CreateStore(file, input, cancellationToken);
    }

    [HttpPut("[action]/{storeId}")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<Store>> ChangeStoreType(Guid storeId, StoreType storeType, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        return await _service.ChangeStoreType(userId, storeId, storeType, cancellationToken);
    }

    [HttpPut("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreGeneralSetting>> UpdateStoreGenerallSettings(StoreGeneralSettingRequestDto input, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.UpdateStoreGenerallSettings(userId, input, cancellationToken);
    }

    [HttpPut("[action]/{addressId}")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreAddress>> UpdateStoreAddress(Guid addressId, StoreAddressRequestDto input, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        return await _service.UpdateStoreAddress(userId, addressId, input, cancellationToken);
    }

    [HttpGet("[action]/{storeId}")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreGeneralSetting>> GetStoreGenerallSettings(Guid storeId, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        return await _service.GetStoreGenerallSettings(userId, storeId, cancellationToken);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.SystemAdmin)}")]
    public async Task<SingleResponse<Store>> ChangeStoreActivationStatus(Guid createdById, StoreActivationStatusRequestDto input, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        return await _service.ChangeStoreActivationStatus(userId, input, cancellationToken);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreAdmin>> AddStoreAdmin(AddStoreAdminRequestDto input, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.AddStoreAdmin(userId, input, cancellationToken);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreGeneralSetting>> CreateStoreGenerallSettings( StoreGeneralSettingRequestDto settingInput, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.CreateStoreGenerallSettings(userId, settingInput, cancellationToken);
    }

    [HttpGet("[action]/{domainName}")]
    public async Task<SingleResponse<bool>> IsDomainAvailable(string domainName, CancellationToken cancellationToken)
    {
        return await _service.IsDomainAvailable(domainName, cancellationToken);
    }

    [HttpPost("[action]/{storeId}")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<ListResponse<StoreAddress>> CreateStoreAddress(Guid storeId, List<StoreAddressRequestDto> addressInput, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.CreateStoreAddress(userId,storeId, addressInput, cancellationToken);
    }

    [HttpGet("[action]/storeId")]
    public ListResponse<StoreAddress> GetStoreAddress(Guid storeId)
    {
        return _service.GetStoreAddress(storeId);
    }

    [HttpGet("[action]/storeId")]
    public async Task<SingleResponse<StoreDiscussionSetting>> GetStoreDiscussionSetting(Guid storeId, CancellationToken cancellationToken)
    {
        return await _service.GetStoreDiscussionSetting(storeId, cancellationToken);
    }

    [HttpGet("[action]/storeId")]
    public async Task<SingleResponse<StoreMediaOptionSetting>> GetStoreMediaOptions(Guid storeId, CancellationToken cancellationToken)
    {
        return await _service.GetStoreMediaOptions(storeId, cancellationToken);
    }

    [HttpPost("[action]/{storeId}")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreDiscussionSetting>> CreateStoreDiscussionSetting(StoreDiscussionSettingRequestDto input, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.CreateStoreDiscussionSetting(userId,input, cancellationToken);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreMediaOptionSetting>> CreateStoreMediaOptions(StoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.CreateStoreMediaOptions(userId,input, cancellationToken);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> CreateStoreLowThresoldNotificationManagment(
       StoreLowThresoldNotificationManagmentSettingRequestDto input, CancellationToken cancellationToken)
    {
        Guid userId = User.GetUserId();
        return await _service.CreateStoreLowThresoldNotificationManagment(userId,input, cancellationToken);
    }

    [HttpGet("[action]")]
    public async Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> GetStoreLowThresoldNotificationManagment(
        Guid storeId, CancellationToken cancellationToken)
    {
        return await _service.GetStoreLowThresoldNotificationManagment(storeId, cancellationToken);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = $"{nameof(RoleType.StoreAdmin)}")]
    public async Task<SingleResponse<StoreReadingSetting>> CreateStoreReadingSettings(StoreReadingSettingRequestDto input, CancellationToken cancellationToken)
    {
       Guid userId = User.GetUserId() ;
        return await _service.CreateStoreReadingSettings(userId,input, cancellationToken);
    }

    [HttpGet("[action]")]
    public async Task<SingleResponse<StoreReadingSetting>> GetStoreReadingSettings(Guid storeId, CancellationToken cancellationToken)
    {
        return await _service.GetStoreReadingSettings(storeId, cancellationToken);
    }

    [HttpGet("[action]/{productId}")]
    public async Task<SingleResponse<StoreResponseDto>> GetStoreProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
    {
        return await _service.GetStoreProductId(productId, cancellationToken);
    }
}

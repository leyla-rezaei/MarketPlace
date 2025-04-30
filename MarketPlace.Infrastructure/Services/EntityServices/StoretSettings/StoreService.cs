using FluentValidation;
using Mapster;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.MultiMediaFiles;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Enums.StoreSetting;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using MarketPlace.StoretSettings.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings;

public class StoreService : BaseService<Store, StoreRequestDto, StoreResponseDto>, IStoreService
{
    private readonly IBaseRepository<Store> _repository;
    private readonly IMultiMediaFileService _fileService;
    private readonly IAuthenticationService _authenticationService;
    private readonly IValidator<StoreRequestDto> _storeValidator;
    private readonly IProductService _productService;

    public StoreService(IBaseRepository<Store> repository,
        IMultiMediaFileService fileService,
        IAuthenticationService authenticationService,
        IValidator<StoreRequestDto> storeValidator,
         IProductService productService) : base(repository)
    {
        _repository = repository;
        _fileService = fileService;
        _authenticationService = authenticationService;
        _storeValidator = storeValidator;
        _productService = productService;
    }

    public async Task<SingleResponse<Store>> CreateStore(IFormFile file, CreateStoreRequestDto input,
        CancellationToken cancellationToken)
    {

        var storeValidation = _storeValidator.Validate(input.StoreInput).GetAllErrorsString();
        if (storeValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeValidation);


        User? user = await GetAllAsNoTracking<User>().Where(x => x.Id == input.StoreInput.OwnerId).FirstOrDefaultAsync(cancellationToken);
        if (user is null) return ResponseStatus.UserNotFound;

        if (file is not null || file.Length > 0)
        {
            var fileResult = await _fileService.SaveMedia(file, input.FileInput, cancellationToken);

            if (fileResult.Status == ResponseStatus.Success)
                input.StoreInput.StoreIconId = fileResult.Result.Id;
        }

        var store = input.StoreInput.Adapt<Store>();
        store.ActivationStatus = StoreActivationStatus.Pending;
        await _repository.Create(store, cancellationToken);


        if (store.Id == Guid.Empty)
        {
            if (input.StoreInput.StoreIconId is not null) await _fileService.Delete(input.StoreInput.StoreIconId.Value, cancellationToken);

            return ResponseStatus.UnknownError;
        }


        await CreateStoreGenerallSettings(new()
        {
            StoreIconId = input.StoreInput.StoreIconId.Value,
            StoreId = store.Id,
            StoreSubDomian = input.StoreInput.Domain,
            Localizations = input.StoreInput.Localizations.Select(x => new StoreGeneralSettingLocalizationDto { Title = x.Title, Description = x.Description, Key = x.Key }).ToList(),
        }, cancellationToken);

        //TODO Send notification to admin to check the store and change status to confirmed
        //TODO Send notification to store owner 
        return store;
    }

    public async Task<SingleResponse<Store>> ChangeStoreType(Guid userId, Guid storeId, StoreType storeType, CancellationToken cancellationToken)
    {
        Store? store = await GetAll().Where(x => x.Id == storeId).FirstOrDefaultAsync(cancellationToken);
        if (store is null) return ResponseStatus.StoreNotFound;

        if (store.OwnerId != userId)
        {
            return ResponseStatus.UserIsNotStorOwner;
        }

        return await _repository.Update(storeId, store, cancellationToken);

        //TODO Send notification to store owner 
        return store;
    }

    public async Task<SingleResponse<Store>> ChangeStoreActivationStatus(Guid createdById, StoreActivationStatusRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAll().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);
        if (store is null) return ResponseStatus.StoreNotFound;

        store.ActivationStatus = input.ActivationStatus;
        store.CreatedById = createdById;

        await _repository.Update(input.StoreId, store, cancellationToken);

        //TODO Send notification to store owner to know about confirmation status

        return store;
    }

    public async Task<SingleResponse<StoreAdmin>> AddStoreAdmin(Guid userId, AddStoreAdminRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAll().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;
        if (store is null) return ResponseStatus.StoreNotFound;

        var isUserAddedBefore = await GetAllAsNoTracking<StoreAdmin>()
            .Where(x => x.StoreId == input.StoreId && x.AdminId == input.UserId)
            .AnyAsync(cancellationToken);

        if (isUserAddedBefore) return ResponseStatus.UserAlreadyAdded;

        bool isUserExist = GetAll<User>().Where(x => x.Id == input.UserId).Any();
        if (!isUserExist) return ResponseStatus.UserNotFound;

        var storeAdminResult = await Create<StoreAdmin, StoreAdmin>(new StoreAdmin
        {
            AdminId = input.UserId,
            StoreId = input.StoreId,
        }, cancellationToken);

        return storeAdminResult;
    }

    public async Task<JustResponse> RemoveAdminFromStore(AddStoreAdminRequestDto input, CancellationToken cancellationToken)
    {
        var admin = await GetAllAsNoTracking<StoreAdmin>()
            .Where(x => x.StoreId == input.StoreId && x.AdminId == input.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        if (admin is null) return ResponseStatus.UserNotFound;

        return await Delete<StoreAdmin>(admin.Id, cancellationToken);
    }

    public async Task<SingleResponse<StoreGeneralSetting>> GetStoreGenerallSettings(Guid userId, Guid storeId, CancellationToken cancellationToken)
    {
        Store? store = await GetAllAsNoTracking().Where(x => x.Id == storeId).FirstOrDefaultAsync(cancellationToken);

        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        var settings = await GetAllAsNoTracking<StoreGeneralSetting>().Where(x => x.StoreId == storeId).FirstOrDefaultAsync(cancellationToken);
        return settings;
    }

    public async Task<SingleResponse<bool>> IsDomainAvailable(string domainName, CancellationToken cancellationToken)
    {
        string pattern = "[' ,.~!@#$%^&*()_+=\\-?\\\\;'/*]";
        if (Regex.IsMatch(domainName, pattern))
            return false;

        return await GetAllAsNoTracking<StoreGeneralSetting>()
        .AnyAsync(x => x.StoreSubDomian == domainName, cancellationToken);
    }

    public async Task<ListResponse<StoreAddress>> CreateStoreAddress(Guid userId, Guid storeId, List<StoreAddressRequestDto> addressInput, CancellationToken cancellationToken)
    {
        Store? store = await GetAll().Where(x => x.Id == storeId).FirstOrDefaultAsync(cancellationToken);
        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        var addresses = addressInput.Adapt<List<StoreAddress>>();

        addresses.ForEach(x => x.StoreId = storeId);

        foreach (var address in addresses)
        {
            await Create<StoreAddress, StoreAddress>(address, cancellationToken);
        }

        return addresses;
    }

    public async Task<SingleResponse<StoreAddress>> UpdateStoreAddress(Guid userId, Guid addressId, StoreAddressRequestDto input, CancellationToken cancellationToken)
    {
        StoreAddress? address = await GetAll<StoreAddress>()
            .Where(x => x.Id == addressId)
            .FirstOrDefaultAsync(cancellationToken);

        if (address is null) return ResponseStatus.NotFound;

        Store? store = await GetAll().Where(x => x.Id == address.StoreId).FirstOrDefaultAsync(cancellationToken);
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        return await Update<StoreAddress, StoreAddressRequestDto>(addressId, input, cancellationToken);
    }

    public ListResponse<StoreAddress> GetStoreAddress(Guid storeId)
    {
        var addresses = GetAll<StoreAddress>().Where(x => x.StoreId == storeId);

        if (!addresses.Any()) return ResponseStatus.NotFound;

        return addresses.ToList();
    }

    public async Task<SingleResponse<StoreDiscussionSetting>> CreateStoreDiscussionSetting(Guid userId, StoreDiscussionSettingRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAllAsNoTracking().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);

        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        StoreDiscussionSetting? setting = await GetAll<StoreDiscussionSetting>()
            .Where(x => x.StoreId == input.StoreId)
            .FirstOrDefaultAsync(cancellationToken);

        if (setting is not null)
            return await Update<StoreDiscussionSetting, StoreDiscussionSettingRequestDto>(setting.Id, input, cancellationToken);

        return await Create<StoreDiscussionSetting, StoreDiscussionSettingRequestDto>(input, cancellationToken);
    }

    public async Task<SingleResponse<StoreDiscussionSetting>> GetStoreDiscussionSetting(Guid storeId, CancellationToken cancellationToken)
    {
        var setting = await GetAll<StoreDiscussionSetting>()
            .Where(x => storeId == storeId)
            .FirstOrDefaultAsync(cancellationToken);

        if (setting is null) return ResponseStatus.NotFound;

        return setting;
    }

    public async Task<SingleResponse<StoreMediaOptionSetting>> CreateStoreMediaOptions(Guid userId, StoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAllAsNoTracking().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);

        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;


        StoreMediaOptionSetting? setting = await GetAll<StoreMediaOptionSetting>()
            .Where(x => x.StoreId == input.StoreId)
            .FirstOrDefaultAsync(cancellationToken);

        if (setting is not null)
            return await Update<StoreMediaOptionSetting, StoreMediaOptionSettingRequestDto>(setting.Id, input, cancellationToken);

        return await Create<StoreMediaOptionSetting, StoreMediaOptionSettingRequestDto>(input, cancellationToken);
    }

    public async Task<SingleResponse<StoreMediaOptionSetting>> GetStoreMediaOptions(Guid storeId, CancellationToken cancellationToken)
    {
        var setting = await GetAll<StoreMediaOptionSetting>().Where(x => storeId == storeId).FirstOrDefaultAsync(cancellationToken);
        if (setting is null) return ResponseStatus.NotFound;

        return setting;
    }

    public async Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> CreateStoreLowThresoldNotificationManagment(
        Guid userId, StoreLowThresoldNotificationManagmentSettingRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAllAsNoTracking().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);

        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        StoreLowThresoldNotificationManagmentSetting? setting = await GetAll<StoreLowThresoldNotificationManagmentSetting>()
            .Where(x => x.StoreId == input.StoreId)
            .FirstOrDefaultAsync(cancellationToken);

        if (setting is not null)
            return await Update<StoreLowThresoldNotificationManagmentSetting, StoreLowThresoldNotificationManagmentSettingRequestDto>(setting.Id, input, cancellationToken);

        return await Create<StoreLowThresoldNotificationManagmentSetting, StoreLowThresoldNotificationManagmentSettingRequestDto>(input, cancellationToken);
    }

    public async Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> GetStoreLowThresoldNotificationManagment(
        Guid storeId, CancellationToken cancellationToken)
    {
        var setting = await GetAll<StoreLowThresoldNotificationManagmentSetting>().Where(x => x.StoreId == storeId).FirstOrDefaultAsync(cancellationToken);
        if (setting is null) return ResponseStatus.NotFound;

        return setting;
    }

    public async Task<SingleResponse<StoreReadingSetting>> CreateStoreReadingSettings(Guid userId
        , StoreReadingSettingRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAllAsNoTracking().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);

        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        StoreReadingSetting? setting = await GetAll<StoreReadingSetting>()
            .Where(x => x.StoreId == input.StoreId)
            .FirstOrDefaultAsync(cancellationToken);

        if (setting is not null)
            return await Update<StoreReadingSetting, StoreReadingSettingRequestDto>(setting.Id, input, cancellationToken);

        return await Create<StoreReadingSetting, StoreReadingSettingRequestDto>(input, cancellationToken);
    }

    public async Task<SingleResponse<StoreReadingSetting>> GetStoreReadingSettings(Guid storeId, CancellationToken cancellationToken)
    {
        var setting = await GetAll<StoreReadingSetting>().Where(x => x.StoreId == storeId).FirstOrDefaultAsync(cancellationToken);
        if (setting is null) return ResponseStatus.NotFound;

        return setting;
    }

    public async Task<SingleResponse<StoreGeneralSetting>> CreateStoreGenerallSettings(Guid userId, StoreGeneralSettingRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAllAsNoTracking().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);

        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId != userId) return ResponseStatus.UserIsNotStorOwner;

        StoreGeneralSetting? setting = await GetAll<StoreGeneralSetting>()
                    .Where(x => x.StoreId == input.StoreId)
                    .FirstOrDefaultAsync(cancellationToken);

        if (setting is not null)
            return await Update<StoreGeneralSetting, StoreGeneralSettingRequestDto>(setting.Id, input, cancellationToken);

        return await Create<StoreGeneralSetting, StoreGeneralSettingRequestDto>(input, cancellationToken);

    }

    private async Task<SingleResponse<StoreGeneralSetting>> CreateStoreGenerallSettings(StoreGeneralSettingRequestDto settingInput, CancellationToken cancellationToken)
    {
        var store = GetAll().Where(x => x.Id == settingInput.StoreId).SingleOrDefaultAsync(cancellationToken);

        if (store is null)
            return ResponseStatus.NotFound;

        var mainBussinessSetting = await GetAllAsNoTracking<MainBusinessSetting>().FirstOrDefaultAsync(cancellationToken);

        var mainUrl = mainBussinessSetting.SiteUrl.Split(mainBussinessSetting.Domain);

        var entity = settingInput.Adapt<StoreGeneralSetting>();

        entity.TimeFormat = mainBussinessSetting.TimeFormat;
        entity.DateFormat = mainBussinessSetting.DateFormat;
        entity.TimeZoneId = mainBussinessSetting.TimeZoneId;
        entity.WeekStartOn = mainBussinessSetting.WeekStartOn;
        entity.StoreSubDomianUrl = $"{mainUrl[0]}+{mainBussinessSetting.Domain}";

        await _repository.Create(entity, cancellationToken);

        if (entity.Id == Guid.Empty)
        {
            return ResponseStatus.UnknownError;
        }

        return SingleResponse<StoreGeneralSetting>.Success(entity);
    }

    public async Task<SingleResponse<StoreGeneralSetting>> UpdateStoreGenerallSettings(Guid userId, StoreGeneralSettingRequestDto input, CancellationToken cancellationToken)
    {
        Store? store = await GetAll().Where(x => x.Id == input.StoreId).FirstOrDefaultAsync(cancellationToken);
        if (store is null) return ResponseStatus.StoreNotFound;
        if (store.OwnerId == userId) return ResponseStatus.UserIsNotStorOwner;

        StoreGeneralSetting? setting = await GetAll<StoreGeneralSetting>()
        .Where(x => x.StoreId == input.StoreId)
        .FirstOrDefaultAsync(cancellationToken);

        if (setting is null) return ResponseStatus.NotFound;

        return await Update<StoreGeneralSetting, StoreGeneralSettingRequestDto>(setting.Id, input, cancellationToken);
    }


    public async Task<SingleResponse<StoreResponseDto>> GetStoreProductId(Guid productId, CancellationToken cancellationToken)
    {
        var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

        if (product is null) return ResponseStatus.NotFound;

        var store = new StoreResponseDto
        {
            ActivationStatus = product.Store.ActivationStatus,
            OwnerId = product.Store.OwnerId,
            StoreIconId = product.Store.StoreIconId,
            StoreTypeId = product.Store.StoreTypeId,
            Domain = product.Store.Domain,
            Localizations = product.Store.Localizations
            .Select(x => new StoreLocalizationDto
            {
                Description = x.Description,
                Key = x.Key,
                Title = x.Title
            }).ToList(),
        };
        return store;
    }
}

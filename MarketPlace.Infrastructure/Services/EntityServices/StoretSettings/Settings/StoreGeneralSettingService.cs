using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Settings;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Settings
{
    public class StoreGeneralSettingService : BaseService<StoreGeneralSetting, StoreGeneralSettingRequestDto, StoreGeneralSettingResponseDto>, IStoreGeneralSettingService
    {
        private readonly IValidator<StoreGeneralSettingRequestDto> _storeGeneralSettingValidator;
        public StoreGeneralSettingService(IBaseRepository<StoreGeneralSetting> repository,
            IValidator<StoreGeneralSettingRequestDto> storeGeneralSettingValidator) : base(repository)
        {
            _storeGeneralSettingValidator = storeGeneralSettingValidator;
        }

        public async Task<SingleResponse<StoreGeneralSetting>> CreateStoreGeneralSetting(StoreGeneralSettingRequestDto input, CancellationToken cancellationToken)
        {
            var storeGeneralSettingValidation = _storeGeneralSettingValidator.Validate(input).GetAllErrorsString();
            if (storeGeneralSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, storeGeneralSettingValidation);
            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            var isMultiMediaFileExist = await GetAllAsNoTracking<MultiMediaFile>().Where(x => x.Id == input.StoreIconId).AnyAsync(cancellationToken);
            if (!isMultiMediaFileExist) return ResponseStatus.NotFound;

            var isLanguageExist = await GetAllAsNoTracking<Language>().Where(x => x.Id == input.StoreLanguageId).AnyAsync(cancellationToken);
            if (!isLanguageExist) return ResponseStatus.NotFound;

            var isCountryExist = await GetAllAsNoTracking<Country>().Where(x => x.Id == input.TimeZoneId).AnyAsync(cancellationToken);
            if (!isCountryExist) return ResponseStatus.NotFound;

            return await CreateStoreGeneralSetting(input, cancellationToken);
        }
    }
}
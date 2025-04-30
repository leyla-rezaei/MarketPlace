using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Admin;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Admin;
using MarketPlace.Infrastructure.Identity.Models;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Admin
{
    public class MainBusinessSettingService : BaseService<MainBusinessSetting, MainBusinessSettingRequestDto, MainBusinessSettingResponseDto>, IMainBussimnessSettingService
    {
        private readonly IValidator<MainBusinessSettingRequestDto> _mainBussimnessSettingValidator;
        public MainBusinessSettingService(IBaseRepository<MainBusinessSetting> repository,
            IValidator<MainBusinessSettingRequestDto> mainBussimnessSettingRequestDtoValidator) : base(repository)
        {
            _mainBussimnessSettingValidator = mainBussimnessSettingRequestDtoValidator;
        }
        public async Task<SingleResponse<MainBusinessSetting>> CreateMainBusinessSetting(MainBusinessSettingRequestDto input, CancellationToken cancellationToken)
        {

            var mainBussimnessSettingValidation = _mainBussimnessSettingValidator.Validate(input).GetAllErrorsString();
            if (mainBussimnessSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, mainBussimnessSettingValidation);

            var isCountryExist = await GetAllAsNoTracking<Country>().Where(x => x.Id == input.TimeZoneId).AnyAsync(cancellationToken);
            if (!isCountryExist) return ResponseStatus.NotFound;

            var isRoleExist = await GetAllAsNoTracking<Role>().Where(x => x.Id == input.NewUserDefaultRoleId).AnyAsync(cancellationToken);
            if (!isRoleExist) return ResponseStatus.NotFound;

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.AdminStoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateMainBusinessSetting(input, cancellationToken);
        }

        public async Task<SingleResponse<MainBusinessSetting>> UpdateMainBusinessSetting(Guid id, MainBusinessSettingRequestDto input, CancellationToken cancellationToken)
        {
            var mainBussimnessSettingRequestDtoValidation = _mainBussimnessSettingValidator.Validate(input).GetAllErrorsString();
            if (mainBussimnessSettingRequestDtoValidation.HasValue()) return (ResponseStatus.ValidationFailed, mainBussimnessSettingRequestDtoValidation);

            var isMainBussimnessSettingExist = await GetAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!isMainBussimnessSettingExist) return ResponseStatus.NotFound;

            return await UpdateMainBusinessSetting(id, input, cancellationToken);
        }

        public async Task<SingleResponse<bool>> DeleteMainBusinessSetting(Guid id, CancellationToken cancellationToken)
        {
            var isMainBussimnessSettingExist = await GetAll().Where(x => x.Id == id).AnyAsync(cancellationToken);
            if (!isMainBussimnessSettingExist) return ResponseStatus.NotFound;

            var isLanguageExist = await GetAllAsNoTracking<Language>().Where(x => x.Id == id).AnyAsync(cancellationToken);

            var isCountryExist = await GetAllAsNoTracking<Country>().Where(x => x.Id == id).AnyAsync(cancellationToken);

            var isRoleExist = await GetAllAsNoTracking<Role>().Where(x => x.Id == id).AnyAsync(cancellationToken);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == id).AnyAsync(cancellationToken);

            if (isLanguageExist || isCountryExist || isRoleExist || isStoreExist)
                return ResponseStatus.Failed;

            return await DeleteMainBusinessSetting(id, cancellationToken);
        }
    }
}

using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.PayGateSetting;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.StoretSettings.Selling.PayGateSetting;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infrastructure.Services.EntityServices.StoretSettings.Selling.PayGateSetting
{
    public class ZarinPalSettingService : BaseService<ZarinPalSetting, ZarinPalSettingRequestDto, ZarinPalSettingResponseDto>, IZarinPalSettingService
    {
        private readonly IValidator<ZarinPalSettingRequestDto> _zarinPalSettingValidator;    
        public ZarinPalSettingService(IBaseRepository<ZarinPalSetting> repository,
            IValidator<ZarinPalSettingRequestDto> zarinPalSettingValidator) : base(repository)
        {
            _zarinPalSettingValidator = zarinPalSettingValidator;
        }

        public  async Task<SingleResponse<ZarinPalSetting>> CreateZarinPalSetting(ZarinPalSettingRequestDto input, CancellationToken cancellationToken)
        {
            var zarinPalSettingValidation = _zarinPalSettingValidator.Validate(input).GetAllErrorsString();
            if (zarinPalSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, zarinPalSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreateZarinPalSetting(input, cancellationToken);
        }
    }
}

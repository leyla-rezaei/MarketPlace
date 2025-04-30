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
    public class PayPalSettingService : BaseService<PayPalSetting, PayPalSettingRequestDto, PayPalSettingResponseDto>, IPayPalSettingService
    {
        private readonly IValidator<PayPalSettingRequestDto> _payPalSettingValidator;
        public PayPalSettingService(IBaseRepository<PayPalSetting> repository,
            IValidator<PayPalSettingRequestDto> payPalSettingValidator) : base(repository)
        {
            _payPalSettingValidator = payPalSettingValidator;
        }

        public async Task<SingleResponse<PayPalSetting>> CreatePayPalSetting(PayPalSettingRequestDto input, CancellationToken cancellationToken)
        {
            var payPalSettingValidation = _payPalSettingValidator.Validate(input).GetAllErrorsString();
            if (payPalSettingValidation.HasValue()) return (ResponseStatus.ValidationFailed, payPalSettingValidation);

            var isStoreExist = await GetAllAsNoTracking<Store>().Where(x => x.Id == input.StoreId).AnyAsync(cancellationToken);
            if (!isStoreExist) return ResponseStatus.NotFound;

            return await CreatePayPalSetting(input, cancellationToken);
        }
    }
}

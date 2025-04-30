using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;
using MarketPlace.Dto.StoretSettings.Selling.PayGateSetting;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings.PayGateSetting
{
    public interface IPayPalSettingService
    {
        Task<SingleResponse<PayPalSetting>> CreatePayPalSetting(PayPalSettingRequestDto input, CancellationToken cancellationToken);
    }
}

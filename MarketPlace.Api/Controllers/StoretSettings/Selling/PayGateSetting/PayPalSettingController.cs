using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.PayGateSetting;
using MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;
using MarketPlace.Dto.StoretSettings.Selling.PayGateSetting;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Selling.PayGateSetting
{
    public class PayPalSettingController : ControllerBase
    {
        private readonly IPayPalSettingService _service;
        public PayPalSettingController(IPayPalSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<PayPalSetting>> CreatePayPalSetting(PayPalSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreatePayPalSetting(input, cancellationToken);
        }
    }
}
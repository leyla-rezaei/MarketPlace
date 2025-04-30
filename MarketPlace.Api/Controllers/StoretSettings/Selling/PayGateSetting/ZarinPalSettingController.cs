using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.PayGateSetting;
using MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;
using MarketPlace.Dto.StoretSettings.Selling.PayGateSetting;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Selling.PayGateSetting
{
    public class ZarinPalSettingController : ControllerBase
    {
        private readonly IZarinPalSettingService _service;
        public ZarinPalSettingController(IZarinPalSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ZarinPalSetting>> CreateZarinPalSetting(ZarinPalSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateZarinPalSetting(input, cancellationToken);
        }
    }
}
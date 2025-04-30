using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Setting;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using MarketPlace.Dto.StoretSettings.Selling.Setting;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Setting
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreGeneralSellingSettingsController : ControllerBase
    {
        private readonly IStoreGeneralSellingSettingsService _service;
        public StoreGeneralSellingSettingsController(IStoreGeneralSellingSettingsService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreGeneralSellingSettings>> CreateStoreGeneralSellingSettings(StoreGeneralSellingSettingsRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreGeneralSellingSettings(input, cancellationToken);
        }
    }
}

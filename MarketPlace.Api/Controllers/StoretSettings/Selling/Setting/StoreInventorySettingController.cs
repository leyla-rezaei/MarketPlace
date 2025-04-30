using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Setting;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using MarketPlace.Dto.StoretSettings.Selling.Setting;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Setting
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreInventorySettingController : ControllerBase
    {
        private readonly IStoreInventorySettingService _service;
        public StoreInventorySettingController(IStoreInventorySettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreInventorySetting>> CreateStoreInventorySetting(StoreInventorySettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreInventorySetting(input, cancellationToken);
        }
    }
}

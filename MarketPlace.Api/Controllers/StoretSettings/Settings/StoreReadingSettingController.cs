using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreReadingSettingController : ControllerBase
    {
        private readonly IStoreReadingSettingService _service;
        public StoreReadingSettingController(IStoreReadingSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreReadingSetting>> CreateStoreReadingSetting(StoreReadingSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreReadingSetting(input, cancellationToken);
        }
    }
}

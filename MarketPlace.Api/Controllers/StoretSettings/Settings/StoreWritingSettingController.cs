using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreWritingSettingController : ControllerBase
    {
        private readonly IStoreWritingSettingService _service;
        public StoreWritingSettingController(IStoreWritingSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreWritingSetting>> CreateStoreWritingSetting(StoreWritingSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreWritingSetting(input, cancellationToken);
        }
    }
}
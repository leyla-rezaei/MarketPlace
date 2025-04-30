using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreMediaOptionSettingController : ControllerBase
    {
        private readonly IStoreMediaOptionSettingService _service;
        public StoreMediaOptionSettingController(IStoreMediaOptionSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreMediaOptionSetting>> CreateStoreMediaOptionSetting(StoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreMediaOptionSetting(input, cancellationToken);
        }
    }
}
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreGeneralSettingController : ControllerBase
    {
        private readonly IStoreGeneralSettingService _service;
        public StoreGeneralSettingController(IStoreGeneralSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public  async Task<SingleResponse<StoreGeneralSetting>> CreateStoreGeneralSetting(StoreGeneralSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreGeneralSetting(input, cancellationToken);   
        }
    }
}

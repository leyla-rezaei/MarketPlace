using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreDiscussionSettingController : ControllerBase
    {
        private readonly IStoreDiscussionSettingService _service;
        public StoreDiscussionSettingController(IStoreDiscussionSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<StoreDiscussionSetting>> CreateStoreDiscussionSetting(StoreDiscussionSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateStoreDiscussionSetting(input, cancellationToken);
        }
    }
}

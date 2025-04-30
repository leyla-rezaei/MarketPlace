using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings.Settings;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Api.Controllers.StoretSettings.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreLowThresoldNotificationManagmentSettingController : ControllerBase
    {
        private readonly IStoreLowThresoldNotificationManagmentSettingService _service;
        public StoreLowThresoldNotificationManagmentSettingController(IStoreLowThresoldNotificationManagmentSettingService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public   async Task<SingleResponse<StoreLowThresoldNotificationManagmentSetting>> CreateStoreLowThresoldNotificationManagmentSetting(StoreLowThresoldNotificationManagmentSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await  _service.CreateStoreLowThresoldNotificationManagmentSetting(input, cancellationToken);
        }
    }
}

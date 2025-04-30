using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Admin;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Dto.Admin;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Admin
{
    public class MainBusinessSettingController : BaseController<MainBusinessSetting, MainBusinessSettingRequestDto, MainBusinessSettingResponseDto>
    {
        private readonly IMainBussimnessSettingService _service;
        public MainBusinessSettingController(IMainBussimnessSettingService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<MainBusinessSetting>> CreateMainBusinessSetting(MainBusinessSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.Create(input, cancellationToken);
        }

        [HttpPut("[action]")]
        public async Task<SingleResponse<MainBusinessSetting>> UpdateMainBusinessSetting(Guid id, MainBusinessSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.UpdateMainBusinessSetting(id, input, cancellationToken);
        }
    }
}
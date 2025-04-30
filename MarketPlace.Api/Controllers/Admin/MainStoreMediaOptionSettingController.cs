using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Admin;
using MarketPlace.Domain.Entities.Admin;
using MarketPlace.Dto.Admin;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Admin
{
    public class MainStoreMediaOptionSettingController : BaseController<MainStoreMediaOptionSetting, MainStoreMediaOptionSettingRequestDto, MainStoreMediaOptionSettingResponseDto>
    {
        private readonly IMainStoreMediaOptionSettingService _service;
        public MainStoreMediaOptionSettingController(IMainStoreMediaOptionSettingService service) : base(service)
        {
            _service = service;
        }

        [HttpPut("[action]")]
        public async Task<SingleResponse<MainStoreMediaOptionSetting>> UpdateMainStoreMediaOptionSetting(Guid id, MainStoreMediaOptionSettingRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.UpdateMainStoreMediaOptionSetting(id, input, cancellationToken);
        }
    }
}
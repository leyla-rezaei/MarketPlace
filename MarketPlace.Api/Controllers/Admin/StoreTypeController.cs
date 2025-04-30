using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings.Settings;
using MarketPlace.Dto.StoretSettings.Settings;

namespace MarketPlace.Api.Controllers.Admin
{
    public class StoreTypeController : BaseController<StoreType, StoreTypeRequestDto, StoreTypeResponseDto>
    {
        public StoreTypeController(IBaseService<StoreType, StoreTypeRequestDto, StoreTypeResponseDto> service) : base(service)
        {
        }
    }
}

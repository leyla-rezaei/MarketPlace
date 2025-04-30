using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;
namespace MarketPlace.Api.Controllers.StoretSettings.Selling.Shippings
{
    public class ZoneRegionController : BaseController<ZoneRegion, ZoneRegionRequestDto, ZoneRegionResponseDto>
    {
        public ZoneRegionController(IBaseService<ZoneRegion, ZoneRegionRequestDto, ZoneRegionResponseDto> service) : base(service)
        {
        }
    }
}

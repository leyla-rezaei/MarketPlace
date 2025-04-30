using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.StoretSettings.Slider;
using MarketPlace.Dto.StoretSettings.Slider;

namespace MarketPlace.Api.Controllers.StoretSettings.Slider
{
    public class StoreSliderController : BaseController<StoreSlider, StoreSliderRequestDto, StoreSliderResponseDto>
    {
        public StoreSliderController(IBaseService<StoreSlider, StoreSliderRequestDto, StoreSliderResponseDto> service) : base(service)
        {
        }
    }
}

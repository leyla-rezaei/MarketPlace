using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Shippings
{
    public class ShippnigZoneController : BaseController<ShippingZone, ShippingZoneRequestDto, ShippingZoneResponseDto>
    {
        private readonly IShippnigZoneService _service;
        public ShippnigZoneController(IShippnigZoneService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ShippingZone>> CreateShippingZone(ShippingZoneRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateShippingZone(input, cancellationToken);
        }
    }
}

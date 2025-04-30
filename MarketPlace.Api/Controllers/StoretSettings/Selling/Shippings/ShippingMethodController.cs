using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Shippings
{
    public class ShippingMethodController : BaseController<ShippingMethod, ShippingMethodRequestDto, ShippingMethodResponseDto>
    {
        private readonly IShippingMethodService _service;
        public ShippingMethodController(IShippingMethodService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ShippingMethod>> CreateShippingMethod(ShippingMethodRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateShippingMethod(input, cancellationToken);
        }
    }
}

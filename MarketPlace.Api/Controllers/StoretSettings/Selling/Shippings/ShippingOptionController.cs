using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Shippings
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingOptionController : ControllerBase
    {
        private readonly IShippingOptionService _service;
        public ShippingOptionController(IShippingOptionService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ShippingOption>> CreateShippingOption(ShippingOptionRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateShippingOption(input, cancellationToken);
        }
    }
}

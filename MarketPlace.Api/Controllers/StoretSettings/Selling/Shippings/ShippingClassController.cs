using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;
using MarketPlace.Dto.StoretSettings.Shippings;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Shippings
{
    public class ShippingClassController : BaseController<ShippingClass, ShippingClassRequestDto, ShippingClassResponseDto>
    {
        private readonly IShippingClassService _service;
        public ShippingClassController(IShippingClassService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ShippingClass>> CreateShippingClass(ShippingClassRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateShippingClass(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<SingleResponse<ShippingClassResponseDto>> GetShippingClassesById([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetShippingClassesById(productId, cancellationToken);
        }
    }
}
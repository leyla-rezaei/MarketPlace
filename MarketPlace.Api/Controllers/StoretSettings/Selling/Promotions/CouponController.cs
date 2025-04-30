using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Dto.StoretSettings.Selling.Promotions;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.StoretSettings.Promotions
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _service;
        public CouponController(ICouponService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<Coupon>> CreateCoupon(CouponRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateCoupon(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<SingleResponse<CouponResponseDto>> GetCouponByProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetCouponByProductId(productId, cancellationToken);
        }
    }
}
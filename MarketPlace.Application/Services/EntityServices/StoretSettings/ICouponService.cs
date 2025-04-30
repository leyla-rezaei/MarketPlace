using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Dto.StoretSettings.Selling.Promotions;

namespace MarketPlace.Application.Services.EntityServices.StoretSettings
{
    public interface ICouponService 
    {
        Task<SingleResponse<Coupon>> CreateCoupon(CouponRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<CouponResponseDto>> GetCouponByProductId(Guid productId, CancellationToken cancellationToken);
    }
}

using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Dto.Products.Pricing;


namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IDiscountPriceService : IBaseService<DiscountPrice, DiscountPriceRequestDto, DiscountPriceResponseDto>
    {
        Task<SingleResponse<DiscountPrice>> CreateDiscountPriceService(DiscountPriceRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<DiscountPriceResponseDto>> GetDiscountPriceByProductId(Guid productId, CancellationToken cancellationToken);
    }
}

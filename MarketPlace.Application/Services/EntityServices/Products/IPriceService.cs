using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Dto.Products.Pricing;

namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IPriceService : IBaseService<Price, PriceRequestDto, PriceResponseDto>
    {
        Task<SingleResponse<Price>> CreatePrice(PriceRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<PriceResponseDto>> GetPriceByProductId(Guid productId, CancellationToken cancellationToken);
    }
}

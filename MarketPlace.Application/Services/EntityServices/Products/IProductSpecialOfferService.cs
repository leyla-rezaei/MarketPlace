using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IProductSpecialOfferService : IBaseService<ProductSpecialOffer,ProductSpecialOfferRequestDto,ProductSpecialOfferResponseDto>
    {
        Task<SingleResponse<ProductSpecialOffer>> CreateProductSpecialOffer(ProductSpecialOfferRequestDto input, CancellationToken cancellationToken);
        Task<List<ProductSpecialOfferResponseDto>> GetProductSpecialOffersByProductId(Guid productId, CancellationToken cancellationToken);
    }
}

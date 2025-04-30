using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Services.EntityServices.Products;

public interface IProductService
{
    Task<SingleResponse<Product>> CreateProduct(CreateProductRequestDto input, CancellationToken cancellationToken);
    Task<SingleResponse<ProductResponseDto>> GetProduct(Guid productId, CancellationToken cancellationToken);
}
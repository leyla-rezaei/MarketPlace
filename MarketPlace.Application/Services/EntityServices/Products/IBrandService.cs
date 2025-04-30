using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Dto.Products;

namespace MarketPlace.Application.Services.EntityServices.Products
{
    public interface IBrandService
    {
        Task<SingleResponse<Brand>> CreateBrand(BrandRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<BrandResponseDto>> GetBrandByProductId(Guid productId, CancellationToken cancellationToken);
        Task<ListResponse<BrandSummaryResponseDto>> GetBrands(string languageKey, CancellationToken cancellationToken);
        Task<SingleResponse<Brand>> UpdateBrand(Guid id, BrandRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<bool>> DeleteBrand(Guid brandId, BrandRequestDto input, bool IsActive, CancellationToken cancellationToken);
    }
}

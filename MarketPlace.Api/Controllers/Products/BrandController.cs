using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Dto.Products;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<Brand>> CreateBrand([FromBody] BrandRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateBrand(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<SingleResponse<BrandResponseDto>> GetBrandByProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetBrandByProductId(productId, cancellationToken);
        }

        [HttpGet("[action]/{languageKey}")]
        public async Task<ListResponse<BrandSummaryResponseDto>> GetBrands([FromRoute] string languageKey, CancellationToken cancellationToken)
        {
            return await _service.GetBrands(languageKey, cancellationToken);
        }

        [HttpPut("[action]")]
        public async Task<SingleResponse<Brand>> UpdateBrand(Guid id, BrandRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.UpdateBrand(id, input, cancellationToken);
        }

        [HttpDelete("[action]")]
        public async Task<SingleResponse<bool>> DeleteBrand(Guid brandId, BrandRequestDto brandRequestDto, bool IsActive, CancellationToken cancellationToken)
        {
            return await _service.DeleteBrand(brandId, brandRequestDto, IsActive, cancellationToken);
        }
    }
}
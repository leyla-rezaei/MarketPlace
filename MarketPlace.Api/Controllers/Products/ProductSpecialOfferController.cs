using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Dto.Products;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Api.Controllers.Products
{
    public class ProductSpecialOfferController : BaseController<ProductSpecialOffer, ProductSpecialOfferRequestDto, ProductSpecialOfferResponseDto>
    {
        private readonly IProductSpecialOfferService _service;
        public ProductSpecialOfferController(IProductSpecialOfferService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ProductSpecialOffer>> CreateProductSpecialOffer(ProductSpecialOfferRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateProductSpecialOffer(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<List<ProductSpecialOfferResponseDto>> GetProductSpecialOffersByProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetProductSpecialOffersByProductId(productId, cancellationToken);
        }
    }
}

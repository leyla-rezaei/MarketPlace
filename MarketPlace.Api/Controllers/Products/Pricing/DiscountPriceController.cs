using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Dto.Products.Pricing;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products.Pricing
{
    public class DiscountPriceController : BaseController<DiscountPrice, DiscountPriceRequestDto, DiscountPriceResponseDto>
    {
        private readonly IDiscountPriceService _service;
        public DiscountPriceController(IDiscountPriceService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<DiscountPrice>> CreateDiscountPriceService(DiscountPriceRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateDiscountPriceService(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<SingleResponse<DiscountPriceResponseDto>> GetDiscountPriceByProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetDiscountPriceByProductId(productId, cancellationToken);
        }
    }
}

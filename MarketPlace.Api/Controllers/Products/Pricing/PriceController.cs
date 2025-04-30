using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products.Pricing;
using MarketPlace.Dto.Products.Pricing;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products.Pricing
{
    public class PriceController : BaseController<Price, PriceRequestDto, PriceResponseDto>
    {
        private readonly IPriceService _service;
        public PriceController(IPriceService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<Price>> CreatePrice(PriceRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreatePrice(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<SingleResponse<PriceResponseDto>> GetPriceByProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetPriceByProductId(productId, cancellationToken);
        }
    }
}

using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products.Installment;
using MarketPlace.Dto.Products.Installment;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products.Installment
{
    public class ProductInstallmentController : BaseController<ProductInstallment, ProductInstallmentRequestDto, ProductInstallmentResponseDto>
    {
        private readonly IProductInstallmentService _service;
        public ProductInstallmentController(IProductInstallmentService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<ProductInstallment>> CreateProductInstallment(ProductInstallmentRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateProductInstallment(input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<ListResponse<ProductInstallmentResponseDto>> GetProductInstallmentsByProductId([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetProductInstallmentsByProductId(productId, cancellationToken);
        }
    }
}
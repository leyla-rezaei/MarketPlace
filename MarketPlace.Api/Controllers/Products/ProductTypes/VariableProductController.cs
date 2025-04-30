using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using MarketPlace.Dto.Products.ProductTypes;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products.ProductTypes
{
    public class VariableProductController : ControllerBase
    {
        private readonly IVariableProductService _service;
        public VariableProductController(IVariableProductService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<VariableProduct>> CreateVariableProduct(VariableProductRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateVariableProduct(input, cancellationToken);
        }
    }
}

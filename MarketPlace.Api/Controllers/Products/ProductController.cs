using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Products;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Dto.Products;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Products;

[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost("[action]")]
    public async Task<SingleResponse<Product>> CreateProduct(CreateProductRequestDto input, CancellationToken cancellationToken)
    {
        return await _service.CreateProduct(input, cancellationToken);
    }

    [HttpGet("[action]")]
    public async Task<SingleResponse<ProductResponseDto>> GetProduct(Guid productId, CancellationToken cancellationToken)
    {
        return await _service.GetProduct(productId, cancellationToken);
    }
}
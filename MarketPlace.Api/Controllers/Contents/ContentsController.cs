using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Contents;
using MarketPlace.Domain.Entities.Contents;
using MarketPlace.Dto.Contents;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Contents;

[Route("api/[controller]")]
[ApiController]
public class ContentsController : ControllerBase
{
    private readonly IContentService _service;
    public ContentsController(IContentService service)
    {
        _service = service;
    }

    [HttpPost("[action]/{productId}")]
    public async Task<SingleResponse<ProductContent>> CreateProductContent(ProductContentRequestDto input, CancellationToken cancellationToken)
    {
        return await _service.CreateProductContent(input, cancellationToken);
    }

    [HttpPut("[action]/{id}")]
    public async Task<SingleResponse<ProductContent>> Update([FromRoute] Guid id, Guid productId, ProductContentRequestDto input, string languageKey, CancellationToken cancellationToken)
    {
        return await _service.Update(id, productId, input, languageKey, cancellationToken);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        return await _service.Delete(id, cancellationToken);
    }

    [HttpGet("[action]/{productId}")]
    public async Task<SingleResponse<ContentResponseDto>> GetContentByProductId([FromRoute] Guid productId, CancellationToken cancellationToken = default)
    {
        return await _service.GetContentByProductId(productId, cancellationToken);
    }

    [HttpGet("[action]")]
    public async Task<JustResponse> IsContentAllowedGenerally([FromBody] List<string> contents, [FromQuery] bool checkHoldQueueWords = false, CancellationToken cancellationToken = default)
    {
        return await _service.IsContentAllowedGenerally(contents, checkHoldQueueWords, cancellationToken);
    }
}
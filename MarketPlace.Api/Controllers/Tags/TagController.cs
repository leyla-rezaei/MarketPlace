using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Tags;
using MarketPlace.Domain.Entities.Tags;
using MarketPlace.Dto.Tags;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Tags
{
    public class TagController : BaseController<Tag, TagRequestDto, TagResponseDto>
    {
        private readonly ITagService _service;
        public TagController(ITagService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("CheckTagIds")]
        public JustResponse CheckTagIds(List<Guid> ids)
        {
            return CheckTagIds(ids);

        }

        [HttpGet("[action]/{productId}")]
        public async Task<ListResponse<TagResponseDto>> GetProductTags([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetProductTags(productId, cancellationToken);
        }
    }
}
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Tags;
using MarketPlace.Dto.Tags;

namespace MarketPlace.Application.Services.EntityServices.Tags;

public interface ITagService : IBaseService<Tag, TagRequestDto, TagResponseDto>
{
    JustResponse CheckTagIds(List<Guid> ids);
    Task<ListResponse<TagResponseDto>> GetProductTags(Guid productId, CancellationToken cancellationToken);

}
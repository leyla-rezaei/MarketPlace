using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Tags;
using MarketPlace.Domain.Entities.Tags;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Tags;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Tags;

public class TagService : BaseService<Tag, TagRequestDto, TagResponseDto>, ITagService
{
    public TagService(IBaseRepository<Tag> repository) : base(repository)
    {
    }

    public JustResponse CheckTagIds(List<Guid> ids)
    {
        var idsAreAvailable = GetAll().Where(x => ids.Contains(x.Id)).Count() == ids.Count();

        if (idsAreAvailable)
            return ResponseStatus.Success;
        else
            return ResponseStatus.Failed;
    }

    public async Task<ListResponse<TagResponseDto>> GetProductTags(Guid productId, CancellationToken cancellationToken)
    {
        var tags = await base.GetAllAsNoTracking<ProductTag>()
            .Where(tag => tag.ProductId == productId)
            .Select(tag => new TagResponseDto
            {
                Id = tag.Id,
                TagType = TagType.Product,
                IsApproved = tag.Tag.IsApproved,
                Localizations = tag.Tag.Localizations.Select(x => new TagLocalizationDto { TagName = x.TagName, Key = x.Key }).ToList(),

            }).ToListAsync(cancellationToken);

        return tags;
    }
}

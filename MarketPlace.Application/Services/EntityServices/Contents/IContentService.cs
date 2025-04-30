using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Contents;
using MarketPlace.Dto.Contents;

namespace MarketPlace.Application.Services.EntityServices.Contents
{
    public interface IContentService : IBaseService<ProductContent, ContentRequestDto, ContentResponseDto>
    {
        Task<SingleResponse<ProductContent>> CreateProductContent(ProductContentRequestDto input, CancellationToken cancellationToken);
        Task<SingleResponse<ContentResponseDto>> GetContentByProductId(Guid productId, CancellationToken cancellationToken);
        Task<JustResponse> IsContentAllowedGenerally(List<string> content, bool checkHoldKeywords = false, CancellationToken cancellationToken = default);
        Task<SingleResponse<ProductContent>> Update(Guid id, Guid productId, ProductContentRequestDto input, string languageKey, CancellationToken cancellationToken);
    }

}
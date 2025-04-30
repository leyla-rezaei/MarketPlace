using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Common;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Dto.Comments;

namespace MarketPlace.Application.Services.EntityServices.Comments
{
    public interface ICommentPosetiveNegativePointService : IBaseService<CommentPosetiveNegativePoint, CommentPosetiveNegativePointRequestDto, CommentPosetiveNegativePointResponseDto>
    {
        Task<SingleResponse<CommentPosetiveNegativePoint>> CreateCommentPosetiveNegativePoint(CommentPosetiveNegativePointRequestDto input, CancellationToken cancellationToken);
    }
}

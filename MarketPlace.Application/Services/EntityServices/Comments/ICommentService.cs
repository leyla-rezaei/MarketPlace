using MarketPlace.Application.Response;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Enums;
using MarketPlace.Dto.Comments;


namespace MarketPlace.Application.Services.EntityServices.Comments
{
    public interface ICommentService
    {
        Task<SingleResponse<ProductComment>> CreateProductComment(Guid userId, ProductCommentRequestDto input,CancellationToken cancellationToken);
        Task<SingleResponse<PostComment>> CreatePostComment(Guid userId, PostCommentRequestDto input, CancellationToken cancellationToken);
        Task<ListResponse<CommentResponseDto>> GetProductComments(Guid productId, CancellationToken cancellationToken);
        Task<ListResponse<CommentResponseDto>> GetPageComments(Guid pageId, CancellationToken cancellationToken);
        Task<JustResponse> ChangeCommentRequestDto(ChangeCommentStatusRequestDto request, CommentStatus commentStatus, CancellationToken cancellationToken);
    }
}
 
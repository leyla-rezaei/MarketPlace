using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Comments;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Enums;
using MarketPlace.Dto.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlace.Api.Controllers.Comments
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        //[Authorize]
        [HttpPost("[action]")]
        public async Task<SingleResponse<ProductComment>> CreateProductComment(ProductCommentRequestDto input, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            return await _service.CreateProductComment(userId,input, cancellationToken);
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<SingleResponse<PostComment>> CreatePostComment(PostCommentRequestDto input, CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            return await _service.CreatePostComment(userId, input, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<ListResponse<CommentResponseDto>> GetProductComments([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return await _service.GetProductComments(productId, cancellationToken);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<ListResponse<CommentResponseDto>> GetPageComments([FromRoute]Guid pageId, CancellationToken cancellationToken)
        {
            return await _service.GetPageComments(pageId, cancellationToken);
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<JustResponse> ChangeCommentRequestDto(ChangeCommentStatusRequestDto request, CommentStatus commentStatus, CancellationToken cancellationToken)
        {
            return await _service.ChangeCommentRequestDto(request, commentStatus, cancellationToken);
        }
    }
}
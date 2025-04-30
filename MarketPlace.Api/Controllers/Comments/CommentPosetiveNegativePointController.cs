using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Comments;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Dto.Comments;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Api.Controllers.Comments
{
    public class CommentPosetiveNegativePointController : BaseController<CommentPosetiveNegativePoint, CommentPosetiveNegativePointRequestDto, CommentPosetiveNegativePointResponseDto>
    {
        private readonly ICommentPosetiveNegativePointService _service;

        public CommentPosetiveNegativePointController(ICommentPosetiveNegativePointService service) : base(service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<SingleResponse<CommentPosetiveNegativePoint>> CreateCommentPosetiveNegativePoint(CommentPosetiveNegativePointRequestDto input, CancellationToken cancellationToken)
        {
            return await _service.CreateCommentPosetiveNegativePoint(input, cancellationToken);

        }
    }
}
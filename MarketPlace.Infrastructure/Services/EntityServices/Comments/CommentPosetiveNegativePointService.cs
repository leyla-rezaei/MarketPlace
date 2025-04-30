using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Comments;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Comments;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Services.EntityServices.Comments
{
    public class CommentPosetiveNegativePointService : BaseService<CommentPosetiveNegativePoint, CommentPosetiveNegativePointRequestDto, CommentPosetiveNegativePointResponseDto>, ICommentPosetiveNegativePointService
    {
        private readonly IValidator<CommentPosetiveNegativePointRequestDto> _commentPosetiveNegativePointValidator;
        public CommentPosetiveNegativePointService(IBaseRepository<CommentPosetiveNegativePoint> repository,
            IValidator<CommentPosetiveNegativePointRequestDto> commentPosetiveNegativePointValidator) : base(repository)
        {
            _commentPosetiveNegativePointValidator = commentPosetiveNegativePointValidator;
        }

        public async Task<SingleResponse<CommentPosetiveNegativePoint>> CreateCommentPosetiveNegativePoint(CommentPosetiveNegativePointRequestDto input, CancellationToken cancellationToken)
        {
            var commentPosetiveNegativePointValidation = _commentPosetiveNegativePointValidator.Validate(input).GetAllErrorsString();
            if (commentPosetiveNegativePointValidation.HasValue()) return (ResponseStatus.ValidationFailed, commentPosetiveNegativePointValidation);

            var isCommentExist = await GetAllAsNoTracking<Comment>().Where(x => x.Id == input.CommentId).AnyAsync(cancellationToken);
            if (!isCommentExist) return ResponseStatus.NotFound;

            return await CreateCommentPosetiveNegativePoint(input, cancellationToken);
        }
    }
}

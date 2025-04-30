using FluentValidation;
using MarketPlace.Application.Response;
using MarketPlace.Application.Services.EntityServices.Comments;
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Repositories.Common;
using MarketPlace.Dto.Comments;
using MarketPlace.Infrastructure.Services.EntityServices.Common;
using Microsoft.EntityFrameworkCore;
using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Infrastructure.Services.EntityServices.Comments
{
    public class CommentService : BaseService<Comment, CommentRequestDto, CommentResponseDto>, ICommentService
    {
        private readonly IValidator<CommentRequestDto> _commentValidator;

        public CommentService(IBaseRepository<Comment> repository, IValidator<CommentRequestDto> commentValidator) : base(repository)
        {
            _commentValidator = commentValidator;
        }

        public async Task<SingleResponse<ProductComment>> CreateProductComment(Guid userId, ProductCommentRequestDto input, CancellationToken cancellationToken)
        {
            //validate the input comment
            var commentValidation = _commentValidator.Validate(input).GetAllErrorsString();
            if (commentValidation.HasValue()) return (ResponseStatus.ValidationFailed, commentValidation);

            //check if the product exists
            var isProductExist = await GetAllAsNoTracking<Product>().Where(x => x.Id == input.ProductId).AnyAsync(cancellationToken);
            if (!isProductExist) return ResponseStatus.NotFound;

            //retrieve the user
            var user = await base.GetAllAsNoTracking<User>().Where(x => x.Id == input.UserId).Include(x => x.Localizations).FirstOrDefaultAsync(cancellationToken);
            if (user is null) return ResponseStatus.NotFound;

            input.AuthorEmail = user.Email;
            //input.Author = user.FullName;

            var inputLocalizationsList = input.Localizations.ToList();
            var userLocalizationsList = user.Localizations.ToList();

            int count = Math.Min(inputLocalizationsList.Count, userLocalizationsList.Count);

            for (int i = 0; i < count; i++)
            {
                inputLocalizationsList[i].Author = userLocalizationsList[i].FullName;
            }

            return await Create<ProductComment, ProductCommentRequestDto>(input, cancellationToken);
        }

        public async Task<SingleResponse<PostComment>> CreatePostComment(Guid userId, PostCommentRequestDto input, CancellationToken cancellationToken)
        {
            //validate the input comment
            var commentValidation = _commentValidator.Validate(input).GetAllErrorsString();
            if (commentValidation.HasValue()) return (ResponseStatus.ValidationFailed, commentValidation);

            //check if the post exists
            var isPostExist = await GetAllAsNoTracking<Post>().Where(x => x.Id == input.PostId).AnyAsync(cancellationToken);
            if (!isPostExist) return ResponseStatus.NotFound;

            //retrieve the user
            var user = await base.GetAllAsNoTracking<User>().Where(x => x.Id == input.UserId).Include(x => x.Localizations).FirstOrDefaultAsync(cancellationToken);
            if (user is null) return ResponseStatus.NotFound;

            input.AuthorEmail = user.Email;

            var inputLocalizationsList = input.Localizations.ToList();
            var userLocalizationsList = user.Localizations.ToList();

            int count = Math.Min(inputLocalizationsList.Count, userLocalizationsList.Count);

            for (int i = 0; i < count; i++)
            {
                inputLocalizationsList[i].Author = userLocalizationsList[i].FullName;
            }

            return await Create<PostComment, PostCommentRequestDto>(input, cancellationToken);
        }

        public async Task<ListResponse<CommentResponseDto>> GetProductComments(Guid productId, CancellationToken cancellationToken)
        {
            var product = await GetAllAsNoTracking<Product>()
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);

            if (product is null) return ResponseStatus.NotFound;

            var comments = await base.GetAllAsNoTracking<ProductComment>()
                .Where(comment => comment.ProductId == productId && comment.CommentStatus == CommentStatus.Approved)
                .Select(comment => new CommentResponseDto
                {
                    Id = comment.Id,
                    CommentStatus = comment.CommentStatus,
                    AuthorEmail = comment.AuthorEmail,
                    UserId = comment.UserId,
                    User = comment.User,
                    IsCommentUsefullCount = comment.IsCommentUsefullCount,
                    IsCommentNotUsefullCount = comment.IsCommentNotUsefullCount,
                    ReplyedToCommentId = comment.ReplyedToCommentId,
                    ReplyedToComment = comment.ReplyedToComment,
                    Localizations = comment.Localizations
                    .Select(x => new CommentLocalizationDto
                    {
                        Author = x.Author,
                        Text = x.Text,
                        Key = x.Key
                    }).ToList(),

                }).ToListAsync(cancellationToken);
            return comments;
        }

        public async Task<ListResponse<CommentResponseDto>> GetPageComments(Guid pageId, CancellationToken cancellationToken)
        {
            var comments = await base.GetAllAsNoTracking<PostComment>()
                .Where(comment => comment.PostId == pageId && comment.CommentStatus == CommentStatus.Approved)
                .Select(comment => new CommentResponseDto
                {
                    Id = comment.Id,
                    CommentStatus = comment.CommentStatus,
                    AuthorEmail = comment.AuthorEmail,
                    UserId = comment.UserId,
                    User = comment.User,
                    IsCommentUsefullCount = comment.IsCommentUsefullCount,
                    IsCommentNotUsefullCount = comment.IsCommentNotUsefullCount,
                    ReplyedToCommentId = comment.ReplyedToCommentId,
                    ReplyedToComment = comment.ReplyedToComment,
                    Localizations = comment.Localizations
                    .Select(x => new CommentLocalizationDto
                    {
                        Author = x.Author,
                        Text = x.Text,
                        Key = x.Key
                    }).ToList(),

                }).ToListAsync(cancellationToken);
            return comments;
        }

        public async Task<JustResponse> ChangeCommentRequestDto(ChangeCommentStatusRequestDto request, CommentStatus commentStatus, CancellationToken cancellationToken)
        {
            var comment = await GetAll().Where(x => x.Id == request.CommentId).SingleOrDefaultAsync(cancellationToken);

            if (comment == null)
                return ResponseStatus.NotFound;

            comment.CommentStatus = request.CommentStatus;

            var result = await Update(comment, cancellationToken);

            return result.Status;
        }
    }
}

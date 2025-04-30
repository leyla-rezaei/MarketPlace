using FluentValidation;
using MarketPlace.Dto.Comments;

namespace MarketPlace.Application.Validations
{
    public class CommentValidation : AbstractValidator<CommentRequestDto>
    {
        public CommentValidation()
        {

            RuleFor(comment => comment.AuthorEmail)
                .NotEmpty().WithMessage("author email cannot be empty.")
                .EmailAddress().WithMessage("invalid email address.");

            RuleFor(comment => comment.UserId)
                .NotNull().WithMessage("user id cannot be null.");


            RuleFor(comment => comment.ReplyedToCommentId)
                .Must((comment, replyId) => replyId != comment.UserId)
                .WithMessage("cannot reply to your own comment.");

            RuleForEach(x => x.Localizations)
            .SetValidator(new CommentLocalizationValidation());

        }

        public class ProductCommentValidation : AbstractValidator<ProductCommentRequestDto>
        {
            public ProductCommentValidation()
            {
                RuleFor(productComment => productComment.ProductId)
                    .NotEmpty()
                    .WithMessage("product id cannot be empty for product comments.");
            }
        }

        public class PostCommentValidation : AbstractValidator<PostCommentRequestDto>
        {
            public PostCommentValidation()
            {
                RuleFor(postComment => postComment.PostId)
                    .NotEmpty()
                    .WithMessage("post id cannot be empty for post comments.");
            }
        }

        public class CommentLocalizationValidation : AbstractValidator<CommentLocalizationDto>
        {
            public CommentLocalizationValidation()
            {
                RuleFor(x => x.Key)
                     .NotEmpty();

                RuleFor(comment => comment.Text)
                    .NotEmpty()
                    .WithMessage("comment text cannot be empty.");

                RuleFor(comment => comment.Author)
                    .NotEmpty()
                    .WithMessage("author name cannot be empty.");
            }
        }
    }
}

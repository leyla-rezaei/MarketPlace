using MarketPlace.Domain.Enums;
namespace MarketPlace.Dto.Comments
{
    public class CommentRequestDto
    {
        public CommentStatus CommentStatus { get; set; }
        public string AuthorEmail { get; set; }
        public Guid UserId { get; set; }
        public int IsCommentUsefullCount { get; set; }
        public int IsCommentNotUsefullCount { get; set; }
        public Guid? ReplyedToCommentId { get; set; }
        public List<CommentLocalizationDto>? Localizations { get; set; }
    }

    public class CommentLocalizationDto
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }

    public class ProductCommentRequestDto : CommentRequestDto
    {
        public Guid ProductId { get; set; }
    }

    public class PostCommentRequestDto : CommentRequestDto
    {
        public Guid PostId { get; set; }
    }
}
using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Comments
{
    public class CommentResponseDto
    {
        public Guid Id { get; set; }
        public CommentStatus CommentStatus { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public string AuthorEmail { get; set; }
        public int IsCommentUsefullCount { get; set; }
        public int IsCommentNotUsefullCount { get; set; }
        public Guid? ReplyedToCommentId { get; set; }
        public Comment? ReplyedToComment { get; set; }

        public List<CommentLocalizationDto>? Localizations { get; set; } = new();
    }
}

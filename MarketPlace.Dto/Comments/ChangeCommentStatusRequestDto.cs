using MarketPlace.Domain.Enums;

namespace MarketPlace.Dto.Comments
{
    public class ChangeCommentStatusRequestDto
    {
        public CommentStatus CommentStatus { get; set; }
        public Guid CommentId  { get; set; }
    }
}
 
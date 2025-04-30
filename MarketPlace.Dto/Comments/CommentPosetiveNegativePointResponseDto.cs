using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Enums.Comment;

namespace MarketPlace.Dto.Comments
{
    public class CommentPosetiveNegativePointResponseDto
    {
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
        public CommentPoint PointComment { get; set; }

        public List<CommentPosetiveNegativePointLocalizationDto>? Localizations { get; set; } = new();
    }
}

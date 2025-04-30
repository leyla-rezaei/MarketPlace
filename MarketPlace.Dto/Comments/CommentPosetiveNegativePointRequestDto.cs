using MarketPlace.Domain.Enums.Comment;

namespace MarketPlace.Dto.Comments
{
    public class CommentPosetiveNegativePointRequestDto
    {
        public Guid CommentId { get; set; }
        public CommentPoint PointComment { get; set; }
        public List<CommentPosetiveNegativePointLocalizationDto>? Localizations { get; set; }
    }

    public class CommentPosetiveNegativePointLocalizationDto
    {
        public string Key { get; set; }
        public string CommentPoint { get; set; }
    }
}

using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Comment;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Comments;

[Table(nameof(CommentPosetiveNegativePoint), Schema = nameof(SchemaConsts.comment))]
public class CommentPosetiveNegativePoint : BaseEntity
{
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }

    public CommentPoint PointComment { get; set; }

    public ICollection<CommentPosetiveNegativePointLocalization> Localizations { get; set; }
}

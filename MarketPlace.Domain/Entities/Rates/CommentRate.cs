using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Rates;

[Table(nameof(CommentRate), Schema = nameof(SchemaConsts.rate))]
public class CommentRate : BaseEntity
{
    public Guid CommentId { get; set; }
    public Comment Comment { get; set; }
    public Guid RateId { get; set; }
    public Rate Rate { get; set; }
}

using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Rates;

[Table(nameof(PostRate), Schema = nameof(SchemaConsts.rate))]
public class PostRate : BaseEntity
{
    public Guid PostId{ get; set; }
    public Post Post{ get; set; }
    public Guid RateId { get; set; }
    public Rate Rate { get; set; }
}

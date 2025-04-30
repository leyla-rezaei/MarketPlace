using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Tags;

[Table(nameof(PostTag), Schema = nameof(SchemaConsts.tag))]
public class PostTag : BaseEntity
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}

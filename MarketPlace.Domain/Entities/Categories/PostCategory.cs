using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Categories;

[Table(nameof(PostCategory), Schema = nameof(SchemaConsts.post))]
public class PostCategory : BaseEntity
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}

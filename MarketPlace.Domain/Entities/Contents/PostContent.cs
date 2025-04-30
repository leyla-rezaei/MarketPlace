using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Enums.Post;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Contents;

[Table(nameof(PostContent), Schema = nameof(SchemaConsts.content))]

public class PostContent : Content
{
    public PostContent()
    {
        ContentType = ContentType.Post;
    }
    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public ICollection<PostContentLocalization> Localizations { get; set; }
}

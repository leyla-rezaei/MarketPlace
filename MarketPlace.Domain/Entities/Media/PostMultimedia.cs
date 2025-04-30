using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Enums.MultiMediaFiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media;

[Table(nameof(PostMultimedia), Schema = nameof(SchemaConsts.media))]
public class PostMultimedia : MultiMediaFile
{
    public PostMultimedia()
    {
        MediaContentType = MediaContentType.Post;

    }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public bool IsIndex { get; set; }

    public ICollection<PostMultimediaLocalization> Localizations { get; set; }

}

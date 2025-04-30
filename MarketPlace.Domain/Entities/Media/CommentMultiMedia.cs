using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Enums.MultiMediaFiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media;

[Table(nameof(CommentMultiMedia), Schema = nameof(SchemaConsts.media))]
public class CommentMultiMedia : MultiMediaFile
{
    public CommentMultiMedia()
    {
        MediaContentType = MediaContentType.Comment;
    }

    public Guid? CommentId { get; set; }
    public Comment Comment { get; set; }
}

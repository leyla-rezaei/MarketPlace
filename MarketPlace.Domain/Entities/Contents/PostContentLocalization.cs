using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Contents
{
    [Table(nameof(PostContentLocalization), Schema = nameof(SchemaConsts.localization))]
    public class PostContentLocalization : ContentLocalization
    {
        public Guid ContentId { get; set; }
        public PostContent Content { get; set; }
        public string Excerpt { get; set; } = string.Empty;
    }
}

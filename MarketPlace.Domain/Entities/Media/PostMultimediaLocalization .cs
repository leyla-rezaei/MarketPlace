using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media
{
    [Table(nameof(PostMultimediaLocalization), Schema = nameof(SchemaConsts.localization))]
    public class PostMultimediaLocalization : MultiMediaFileLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        
        public Guid PostMultimediaId {  get; set; }
        public PostMultimedia PostMultimedia { get; set; }
    }
}
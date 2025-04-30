using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Enums.MultiMediaFiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media;

[Table(nameof(MultiMediaFile), Schema = nameof(SchemaConsts.media))]
public class MultiMediaFile : BaseEntity
{
    public MediaType MediaType { get; set; }
    public string Url { get; set; }
    public string UniqueUrl { get; set; }

    public long FileSize { get; set; }   
    public FileSizeType? FileSizeType { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public MediaContentType MediaContentType { get; set; }
    public ICollection<MultiMediaFileLocalization> Localizations { get; set; }
}

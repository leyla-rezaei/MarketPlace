using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Domain.Entities.Admin;

public class MainStoreMediaOptionSetting : BaseEntity
{
    public int ThumbnailWidth { get; set; }
    public int ThumbnailHeight { get; set; }

    public bool IsCropThumbnailToExactDimensions { get; set; }

    public int MediumSizeMaxWidth { get; set; }
    public int MediumSizeMaxHeight { get; set; }

    public int LargeSizeMaxWidth { get; set; }
    public int LargeSizeMaxHeight { get; set; }
}

using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreMediaOptionSetting), Schema = nameof(SchemaConsts.store_setting))]
public class StoreMediaOptionSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public int? ThumbnailWidth { get; set; }
    public int? ThumbnailHeight { get; set; }
    public bool UseThumbnailDefault { get; set; }

    public bool? IsCropThumbnailToExactDimensions { get; set; }

    public int? MediumSizeMaxWidth { get; set; }
    public int? MediumSizeMaxHeight { get; set; }
    public bool UseMediumSizeDefault { get; set; }

    public int? LargeSizeMaxWidth { get; set; }
    public int? LargeSizeMaxHeight { get; set; }
    public bool UseLargeSizeDefault { get; set; }
}

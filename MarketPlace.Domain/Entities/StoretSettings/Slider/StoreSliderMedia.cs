using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Slider;

[Table(nameof(StoreSliderMedia), Schema = nameof(SchemaConsts.store_setting))]
public class StoreSliderMedia : BaseEntity
{
    public Guid StoreSliderId { get; set; }
    public StoreSlider StoreSlider { get; set; }

    public Guid MultiMediaFileId { get; set; }
    public MultiMediaFile MultiMediaFile { get; set; }

    public uint Order { get; set; }
}

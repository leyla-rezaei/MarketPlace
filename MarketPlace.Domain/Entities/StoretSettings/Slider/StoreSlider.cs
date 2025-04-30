using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Slider;

[Table(nameof(StoreSlider), Schema = nameof(SchemaConsts.store_setting))]
public class StoreSlider : BaseEntity
{
    #region Navigation properties
    public ICollection<StoreSliderMedia> StoreSliderMedias { get; set; }
    public ICollection<StoreSliderLocalization> Localizations { get; set; }
    #endregion
}

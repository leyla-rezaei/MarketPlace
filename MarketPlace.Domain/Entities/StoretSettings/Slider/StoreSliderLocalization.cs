using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Slider
{
    [Table(nameof(StoreSliderLocalization), Schema = nameof(SchemaConsts.localization))]
    public class StoreSliderLocalization :BaseLocalization
    {
        public string SliderName { get; set; } = string.Empty;

        public Guid StoreSliderId {  get; set; }
        public StoreSlider StoreSlider { get; set; }
    }
}

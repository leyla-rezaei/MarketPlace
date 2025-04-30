using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.StoretSettings.Slider;

namespace MarketPlace.Dto.StoretSettings.Slider
{
    public class StoreSliderMediaResponseDto
    {
        public Guid StoreSliderId { get; set; }
        public StoreSlider StoreSlider { get; set; }

        public Guid MultiMediaFileId { get; set; }
        public MultiMediaFile MultiMediaFile { get; set; }
        public uint Order { get; set; }
    }
}

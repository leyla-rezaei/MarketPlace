
using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreMediaOptionSettingRequestDto
    {
        public Guid StoreId { get; set; }
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
}

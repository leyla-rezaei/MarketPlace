
namespace MarketPlace.Dto.Admin
{
    public class MainStoreMediaOptionSettingResponseDto
    {
        public int ThumbnailWidth { get; set; }
        public int ThumbnailHeight { get; set; }

        public bool IsCropThumbnailToExactDimensions { get; set; }

        public int MediumSizeMaxWidth { get; set; }
        public int MediumSizeMaxHeight { get; set; }

        public int LargeSizeMaxWidth { get; set; }
        public int LargeSizeMaxHeight { get; set; }
    }
}

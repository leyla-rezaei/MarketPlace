using MarketPlace.Domain.Enums.Post;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreWritingSettingRequestDto
    {
        public Guid StoreId { get; set; }
        public Guid DefaultPostCategoryId { get; set; }
        public PostFormat DefaultPostFormat { get; set; }
    }
}

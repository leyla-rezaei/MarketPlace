using MarketPlace.Domain.Entities.Categories;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Post;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreWritingSettingResponseDto
    {
        public Guid Id { get; set; }
        public Store Store { get; set; }
        public Guid DefaultPostCategoryId { get; set; }
        public PostCategory DefaultPostCategory { get; set; }
        public PostFormat DefaultPostFormat { get; set; }
    }
}

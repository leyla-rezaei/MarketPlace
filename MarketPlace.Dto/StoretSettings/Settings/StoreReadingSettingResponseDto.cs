using MarketPlace.Domain.Entities.Posts;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Setting;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreReadingSettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public HomepageDisplay HomepageDisplay { get; set; }
        public Guid? HomePageId { get; set; }
        public Post HomePage { get; set; }

        public Guid? PostsPageId { get; set; }
        public Post PostsPage { get; set; }
        public int BlogPagesShowAtMost { get; set; }
    }
}

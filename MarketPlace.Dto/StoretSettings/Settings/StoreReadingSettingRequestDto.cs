using MarketPlace.Domain.Enums.Setting;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreReadingSettingRequestDto
    {
        public Guid StoreId { get; set; }
        public HomepageDisplay HomepageDisplay { get; set; }
        public Guid HomePageId { get; set; }
        public Guid PostsPageId { get; set; }
        public int BlogPagesShowAtMost { get; set; }
    }
}

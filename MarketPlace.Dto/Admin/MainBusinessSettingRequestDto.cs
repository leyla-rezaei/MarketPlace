using MarketPlace.Domain.Enums.Setting;

namespace MarketPlace.Dto.Admin
{
    public class MainBusinessSettingRequestDto
    {
        public string SiteUrl { get; set; }
        public string Domain { get; set; }
        public string SuperAdministrationEmailAddress { get; set; }
        public Guid NewUserDefaultRoleId { get; set; }
        public Guid TimeZoneId { get; set; }
        public DateFormat DateFormat { get; set; }
        public string CustomDateFormat { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public DayOfWeek WeekStartOn { get; set; }
        public Guid AdminStoreId { get; set; }
        public int NumberOfCharacteriseToHoldInQueue { get; set; }
        public string HoldQueueWords { get; set; }

        public string DisallowedCommentKeys { get; set; }
        public List<MainBussimnessSettingLocalizationDto>? Localizations { get; set; }
    }

    public class MainBussimnessSettingLocalizationDto
    {
        public string Key { get; set; }
        public string SiteTitle { get; set; }
        public string Tagline { get; set; }
    }
}
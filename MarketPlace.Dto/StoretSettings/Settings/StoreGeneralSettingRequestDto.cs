using MarketPlace.Domain.Enums.Setting;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreGeneralSettingRequestDto
    {
        public Guid StoreId { get; set; }
        public string? StoreSubDomian { get; set; }
        public string? StoreSubDomianUrl { get; set; }
        public Guid? StoreIconId { get; set; }
        public Guid TimeZoneId { get; set; }
        public Guid StoreLanguageId { get; set; }
        public DateFormat DateFormat { get; set; }
        public string? CustomDateFormat { get; set; }

        public TimeFormat TimeFormat { get; set; }
        public string? CustomTimeFormat { get; set; }

        public DayOfWeek WeekStartOn { get; set; }
        public List<StoreGeneralSettingLocalizationDto>? Localizations { get; set; }
    }
    public class StoreGeneralSettingLocalizationDto
    {
        public string Key { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

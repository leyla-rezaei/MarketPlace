using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Setting;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreGeneralSettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public string StoreSubDomian { get; set; }
        public string StoreSubDomianUrl { get; set; }
        public Guid? StoreIconId { get; set; }
        public MultiMediaFile StoreIcon { get; set; }
        public Guid TimeZoneId { get; set; }
        public Country TimeZone { get; set; }
        public Guid StoreLanguageId { get; set; }
        public Language StoreLanguage { get; set; }
        public DateFormat DateFormat { get; set; }
        public string? CustomDateFormat { get; set; }
        public TimeFormat TimeFormat { get; set; }
        public string? CustomTimeFormat { get; set; }
        public DayOfWeek WeekStartOn { get; set; }

        public List<StoreGeneralSettingLocalizationDto>? Localizations { get; set; }
    }
}

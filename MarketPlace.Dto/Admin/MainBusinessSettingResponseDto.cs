using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Setting;

namespace MarketPlace.Dto.Admin
{
    public class MainBusinessSettingResponseDto
    {
        public Guid Id { get; set; }
        public string SiteUrl { get; set; }
        public string Domain { get; set; }
        public string SuperAdministrationEmailAddress { get; set; }

        public Guid NewUserDefaultRoleId { get; set; }
        public Guid SiteLanguageId { get; set; }
        public Language SiteLanguage { get; set; }

        public Guid TimeZoneId { get; set; }
        public TimeZone TimeZone { get; set; }
        public DateFormat DateFormat { get; set; }
        public string CustomDateFormat { get; set; }

        public TimeFormat TimeFormat { get; set; }
        public string CustomTimeFormat { get; set; }

        public DayOfWeek WeekStartOn { get; set; }

        public Guid AdminStoreId { get; set; }
        public Store AdminStore { get; set; }

        public int NumberOfCharacteriseToHoldInQueue { get; set; }

        public string HoldQueueWords { get; set; }

        public string DisallowedCommentKeys { get; set; }

        public List<MainBussimnessSettingLocalizationDto>? Localizations { get; set; } = new();
    }
}
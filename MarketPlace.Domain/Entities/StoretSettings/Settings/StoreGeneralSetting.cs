using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Enums.Setting;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreGeneralSetting), Schema = nameof(SchemaConsts.store_setting))]

public class StoreGeneralSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public string StoreSubDomian { get; set; }
    public string StoreSubDomianUrl { get; set; }

    public Guid? StoreIconId { get; set; }
    public MultiMediaFile StoreIcon { get; set; }

    public Guid TimeZoneId { get; set; }
    public Country TimeZone { get; set; }

    public DateFormat DateFormat { get; set; }
    public string? CustomDateFormat { get; set; }

    public TimeFormat TimeFormat { get; set; }
    public string? CustomTimeFormat { get; set; }

    public DayOfWeek WeekStartOn { get; set; }

    public ICollection<StoreGeneralSettingLocalization> Localizations { get; set; }
}

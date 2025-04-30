using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Enums.Setting;
using MarketPlace.Infrastructure.Identity.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Admin;

[Table(nameof(MainBusinessSetting), Schema = nameof(SchemaConsts.main_setting))]
public class MainBusinessSetting : BaseEntity
{

    public string SiteUrl { get; set; }
    public string Domain { get; set; }
    public string SuperAdministrationEmailAddress { get; set; }

    public Guid NewUserDefaultRoleId { get; set; }
    public Role NewUserDefaultRole { get; set; }

    public Guid TimeZoneId { get; set; }
    public Country TimeZone { get; set; }

    public DateFormat DateFormat { get; set; }
    public string CustomDateFormat { get; set; }

    public TimeFormat TimeFormat { get; set; }
    public string CustomTimeFormat { get; set; }

    public DayOfWeek WeekStartOn { get; set; }

    public Guid AdminStoreId { get; set; }
    public Store AdminStore { get; set; }


    #region Content Moderation

    /// <summary>
    /// seperate by |
    /// </summary>
    public string HoldQueueWords { get; set; }
    /// <summary>
    /// seperate by |
    /// </summary>
    public string DisallowedCommentKeys { get; set; }

    public int NumberOfCharacteriseToHoldInQueue { get; set; }

    #endregion


    public ICollection<MainBusinessSettingLocalization> Localizations { get; set; }
}

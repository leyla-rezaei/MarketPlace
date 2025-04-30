using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Admin
{
    [Table(nameof(MainBusinessSettingLocalization), Schema = nameof(SchemaConsts.localization))]
    public class MainBusinessSettingLocalization : BaseLocalization
    {
        public Guid MainBussimnessSettingId { get; set; }
        public MainBusinessSetting MainBussimnessSetting { get; set; }

        public string SiteTitle { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
    }
}

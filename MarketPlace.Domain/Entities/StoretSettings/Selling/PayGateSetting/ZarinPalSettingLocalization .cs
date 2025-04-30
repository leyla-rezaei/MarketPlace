using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting
{
    [Table(nameof(ZarinPalSettingLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ZarinPalSettingLocalization : BaseLocalization
    {
        public string MerchentCode { get; set; } = string.Empty;

        public Guid ZarinPalSettingId {  get; set; }
        public ZarinPalSetting ZarinPalSetting { get; set; }
    }
}

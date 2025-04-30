using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting
{
    [Table(nameof(PayPalSettingLocalization), Schema = nameof(SchemaConsts.localization))]
    public class PayPalSettingLocalization : BaseLocalization
    {
        public string Mode { get; set; } = string.Empty;

        public Guid PayPalSettingId {  get; set; }
        public PayPalSetting PayPalSetting { get; set; }
    }
}

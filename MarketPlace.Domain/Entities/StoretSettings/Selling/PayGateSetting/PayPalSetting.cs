using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;

[Table(nameof(PayPalSetting), Schema = nameof(SchemaConsts.payment_method))]
public class PayPalSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public bool IsEanbled { get; set; }

    public int RequestRetries { get; set; }
    public int ConnectionTimeout { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }

    #region Navigation properties

    public ICollection<PayPalSettingLocalization> Localizations { get; set; }
    #endregion
}

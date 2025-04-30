using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.PayGateSetting;

[Table(nameof(ZarinPalSetting), Schema = nameof(SchemaConsts.payment_method))]
public class ZarinPalSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public bool IsEanbled { get; set; }

    #region Navigation properties
    public ICollection<ZarinPalSettingLocalization> Localizations { get; set; }
    #endregion
}

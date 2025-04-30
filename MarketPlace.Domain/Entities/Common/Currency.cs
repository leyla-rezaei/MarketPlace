using MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Common;

[Table(nameof(Currency), Schema = nameof(SchemaConsts.@base))]
public class Currency : BaseEntity
{
    #region Navigation properties
    public ICollection<StoreGeneralSellingSettings> StoreGeneralSellingSettings { get; set; }
    public ICollection<CurrencyLocalization> Localizations { get; set; }
    #endregion
}

using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Selling.Shipping;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

[Table(nameof(ShippingOption), Schema = nameof(SchemaConsts.selling_setting))]
public class ShippingOption : BaseEntity
{
    #region Calculation
    public bool IsEnableShippingCalculatorOnCartPage { get; set; }
    public bool HideShippingCostsUntilAddressIsEntered { get; set; }
    #endregion

    public ShippingDestination ShippingDestination { get; set; }
    public bool IsDebugModeEanbled { get; set; }

    public Guid StoreId { get; set; }
    public Store Store { get; set; }
}

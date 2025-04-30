using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

[Table(nameof(ShippingMethod), Schema = nameof(SchemaConsts.selling_setting))]
public class ShippingMethod : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
    public bool IsEnabled { get; set; }

    public ICollection<ShippingMethodLocalization> Localizations { get; set; }
}

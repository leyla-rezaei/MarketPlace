using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

[Table(nameof(ShippingClass), Schema = nameof(SchemaConsts.selling_setting))]
public class ShippingClass : BaseEntity
{
    public Store Store { get; set; }
    public Guid StoreId { get; set; }
    public int ProductCount { get; set; }

    #region Navigation properties
    public ICollection<Product> Products { get; set; }
    public ICollection<ShippingClassLocalization> Localizations { get; set; }
    #endregion
}

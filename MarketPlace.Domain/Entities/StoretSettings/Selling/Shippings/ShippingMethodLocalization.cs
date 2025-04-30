using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings
{
    [Table(nameof(ShippingMethodLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ShippingMethodLocalization :BaseLocalization
    {
        public string MethodTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid ShippingMethodId {  get; set; }
        public ShippingMethod ShippingMethod { get; set; }
    }
}

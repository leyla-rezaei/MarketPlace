using MarketPlace.Domain.Entities.Common;

using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings
{
    [Table(nameof(ShippingClassLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ShippingClassLocalization : BaseLocalization
    {
        public string ClassName { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid ShippingClassId {  get; set; }
        public ShippingClass ShippingClass { get; set; }
    }
}

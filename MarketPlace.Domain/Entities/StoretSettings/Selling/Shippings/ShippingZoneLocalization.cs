using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings
{
    [Table(nameof(ShippingZoneLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ShippingZoneLocalization :BaseLocalization
    {
        public string ZoneName { get; set; } = string.Empty;

        public Guid ShippingZoneId {  get; set; }   
        public ShippingZone ShippingZone { get; set; }

    }
}

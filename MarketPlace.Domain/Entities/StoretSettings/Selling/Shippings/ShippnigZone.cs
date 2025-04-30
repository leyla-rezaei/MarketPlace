using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

[Table(nameof(ShippingZone), Schema = nameof(SchemaConsts.selling_setting))]
public class ShippingZone : BaseEntity
{
    public Guid ZoneRegionId { get; set; }
    public ZoneRegion ZoneRegion { get; set; }

    public ICollection<ShippingZoneLocalization> Localizations { get; set; }
}

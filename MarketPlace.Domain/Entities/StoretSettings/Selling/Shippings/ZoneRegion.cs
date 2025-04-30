using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings;

[Table(nameof(ZoneRegion), Schema = nameof(SchemaConsts.selling_setting))]
public class ZoneRegion : BaseEntity
{
    #region navigation properties
    public ICollection<ShippingZone> ShippngZones{ get; set; }
    public ICollection<ZoneRegionLocalization> Localizations { get; set; }
    #endregion
}

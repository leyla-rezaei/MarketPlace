using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Shippings
{
    [Table(nameof(ZoneRegionLocalization), Schema = nameof(SchemaConsts.localization))]
    public class ZoneRegionLocalization :BaseLocalization
    {
        public string Region1 { get; set; } = string.Empty;
        public string Region2 { get; set; } = string.Empty;
        public string Region3 { get; set; } = string.Empty;

        public Guid ZoneRegionId {  get; set; } 
        public ZoneRegion ZoneRegion { get; set; }
    }
}

using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders
{
    [Table(nameof(OrderTrackingLocalization), Schema = nameof(SchemaConsts.localization))]
    public class OrderTrackingLocalization : BaseLocalization
    {
        public string Description { get; set; } = string.Empty;
        public Guid OrderTrackingId {  get; set; }
        public OrderTracking OrderTracking { get; set; }
    }
}

using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Enums.Order;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders;

[Table(nameof(OrderTracking), Schema = nameof(SchemaConsts.order))]
public class OrderTracking : BaseEntity
{
    public OrderTracingStatus OrderTracingStatus { get; set; }
    public OrderTrackingType OrderNoteType { get; set; }

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public ICollection<OrderTrackingLocalization> Localizations { get; set; }
}

using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Enums.Order;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders;

[Table(nameof(OrderNote), Schema = nameof(SchemaConsts.order))]
public class OrderNote : BaseEntity
{
    public OrderNoteType OrderNoteType { get; set; }

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<OrderNoteLocalization> Localizations { get; set; }
}

using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.PspLog;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Domain.Enums.Order;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders.Invoices;

[Table(nameof(Invoice), Schema = nameof(SchemaConsts.order))]
public class Invoice : BaseEntity
{
    public OrderAction OrderAction { get; set; }
    public Guid? UserId { get; set; }
    public User User { get; set; }

    public Guid ShoppingCardId { get; set; }
    public ShoppingCard ShoppingCard { get; set; }

    public string InvoiceNumber { get; set; }
    public OrderStatus OrderStatus { get; set; }

    public decimal Discount { get; set; }

    public Guid? CouponId { get; set; }
    public Coupon? Coupon { get; set; }

    public decimal Amount { get; set; }
    public decimal Payable => Amount - Discount;
    public bool IsPaid { get; set; }
    public DateTimeOffset? PaidOn { get; set; }


    #region Navigation properties
    public ICollection<OrderNote> OrderNotes { get; set; }
    public ICollection<PspSadadLog> PspSadadLogs { get; set; }
    public ICollection<InvoiceLocalization> Localizations { get; set; }
    #endregion
}
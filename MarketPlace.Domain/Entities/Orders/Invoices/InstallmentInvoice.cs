using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.Products.Pricing;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders.Invoices;

[Table(nameof(InstallmentInvoice), Schema = nameof(SchemaConsts.order))]
public class InstallmentInvoice : BaseEntity
{
    public Guid ShoppingCardDetailId { get; set; }
    public ShoppingCardDetail ShoppingCardDetail { get; set; }

    public uint InstallmentNumber { get; set; }

    public Guid PriceId { get; set; }
    public Price Price { get; set; }

    public decimal Payable { get; set; }

    public bool IsPayed { get; set; }
    public DateTimeOffset? PaidOn { get; set; }

}


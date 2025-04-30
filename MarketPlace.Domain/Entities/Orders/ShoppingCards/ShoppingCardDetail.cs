using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders.ShoppingCards;

[Table(nameof(ShoppingCardDetail), Schema = nameof(SchemaConsts.order))]
public class ShoppingCardDetail : BaseEntity
{
    public int Quantity { get; set; }

    public Guid ShoppingCardId { get; set; }
    public ShoppingCard ShoppingCard { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public bool IsInstallmentPayment { get; set; }

    #region Navigation properties
    public ICollection<InstallmentInvoice> InstallmentInvoices { get; set; }
    #endregion
}
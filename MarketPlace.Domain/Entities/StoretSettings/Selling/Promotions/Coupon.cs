using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Entities.Products;
using MarketPlace.Domain.Enums.Selling;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;

[Table(nameof(Coupon), Schema = nameof(SchemaConsts.selling) )]
public class Coupon : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public string Code { get; set; }
 
    public DiscountType DiscountType { get; set; }
    public decimal? Percent { get; set; }

    public DateTimeOffset ValidFrom { get; set; }
    public DateTimeOffset ValidTo { get; set; }

    public int UsableCount { get; set; }
    public int Usage { get; set; }
    public decimal MinInvoiceLimit { get; set; }
    public decimal MaxInvoiceLimit { get; set; }

    public Guid? UserId { get; set; }
    public User User { get; set; }

    public Guid? ProductId { get; set; }
    public Product Product { get; set; }

    #region Navigation properties
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<CouponLocalization> Localizations { get; set; }
    #endregion
}

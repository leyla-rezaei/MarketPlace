using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Products.ProductTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products.Pricing;

[Table(nameof(DiscountPrice), Schema = nameof(SchemaConsts.product))]
public class DiscountPrice : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid? VariableProductId { get; set; }
    public VariableProduct VariableProduct { get; set; }

    public decimal SalePrice { get; set; }
    public DateTimeOffset SalePriceFrom { get; set; }
    public DateTimeOffset SalePriceTo { get; set; }
}

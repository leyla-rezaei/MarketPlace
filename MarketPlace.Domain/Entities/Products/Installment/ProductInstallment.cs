using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products.Installment;

[Table(nameof(ProductInstallment), Schema = nameof(SchemaConsts.product))]
public class ProductInstallment : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public uint NumberOfInstallment { get; set; }
    public decimal BenefitPercent { get; set; }
}

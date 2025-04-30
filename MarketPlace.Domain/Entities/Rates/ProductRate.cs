using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Rates;

[Table(nameof(ProductRate), Schema = nameof(SchemaConsts.rate))]
public class ProductRate : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid RateId { get; set; }
    public Rate Rate { get; set; }

}

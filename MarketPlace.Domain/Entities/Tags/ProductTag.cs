using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Tags;

[Table(nameof(ProductTag), Schema = nameof(SchemaConsts.tag))]
public class ProductTag : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
}

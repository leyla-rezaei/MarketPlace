using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Categories;

[Table(nameof(ProductCategory), Schema = nameof(SchemaConsts.product))]
public class ProductCategory : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

}
